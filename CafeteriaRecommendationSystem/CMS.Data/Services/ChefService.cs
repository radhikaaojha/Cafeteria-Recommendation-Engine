using AutoMapper;
using CMS.Common.Enums;
using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Common;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System.Linq.Expressions;
using System.Text.Json;
using MealType = Common.Enums.MealType;

namespace CMS.Data.Services
{
    public class ChefService : IChefService
    {
        private IFeedbackService _feedbackService;
        private IFoodItemService _foodItemService;
        private INotificationService _notificationService;
        private IWeeklyMenuService _weeklyMenuService;
        private IUserRepository _userRepository;
        private IMapper mapper;
        public ChefService(IFeedbackService feedbackService, INotificationService notificationService,
            IFoodItemService foodItemService, IWeeklyMenuService weeklyMenuService,
            IMapper mapper,
            IUserRepository userRepository)
        {
            _feedbackService = feedbackService;
            _notificationService = notificationService;
            _foodItemService = foodItemService;
            _weeklyMenuService = weeklyMenuService;
            _userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<string> FinalizeMenuItems(string request)
        {
            var dailyMenuRequest = JsonSerializer.Deserialize<MenuInput>(request);

            if (!await HasPlannedMenuForTomorrow())
            {
                throw new InvalidOperationException("Cannot finalise menu if not already planned for tomorrow.");
            }

            if (await HasFinalisedMenuForTomorrow())
            {
                throw new InvalidOperationException("Menu has already been finalised for tomorrow");
            }

            await ValidateFoodItemsFromPlannedMenu(dailyMenuRequest);

            await FinalizeMealItems(dailyMenuRequest.Breakfast, MealType.Breakfast);
            await FinalizeMealItems(dailyMenuRequest.Lunch, MealType.Lunch);
            await FinalizeMealItems(dailyMenuRequest.Dinner, MealType.Dinner);

            await NotifyEmployeesForPlannedMenu(dailyMenuRequest);
            
            return "Notifications for finalized menu has been sent successfully!";
        }


        public async Task NotifyEmployeesForFinalizeedMenu(MenuInput finalMenu)
        {
            var message = new System.Text.StringBuilder();
            if (finalMenu.Breakfast.Count > 0)
            {
                message.Append("The following items are decided to be made for breakfast:");
                message.Append(string.Join(", ", finalMenu.Breakfast));
                message.Append(". ");
            }

            if (finalMenu.Lunch.Count > 0)
            {
                message.Append("The following items are decided to be made for lunch:");
                message.Append(string.Join(", ", finalMenu.Lunch));
                message.Append(". ");
            }

            if (finalMenu.Dinner.Count > 0)
            {
                message.Append("The following items are decided to be made for dinner:");
                message.Append(string.Join(", ", finalMenu.Dinner));
                message.Append(". ");
            }
            message.Append("Finalised Menu for tomorrow is here");
            await _notificationService.SendBatchNotifications(message.ToString(), AppConstants.Employee, (int)NotificationType.FinalMenu);
        }

        public async Task NotifyEmployeesForPlannedMenu(MenuInput plannedMenu)
        {
            var message = new System.Text.StringBuilder();
            if (plannedMenu.Breakfast.Count > 0)
            {
                message.Append("The following items are planned to be made for breakfast:");
                message.Append(string.Join(", ", plannedMenu.Breakfast));
                message.Append(". ");
            }

            if (plannedMenu.Lunch.Count > 0)
            {
                message.Append("The following items are planned to be made for lunch:");
                message.Append(string.Join(", ", plannedMenu.Lunch));
                message.Append(". ");
            }

            if (plannedMenu.Dinner.Count > 0)
            {
                message.Append("The following items are planned to be made for dinner:");
                message.Append(string.Join(", ", plannedMenu.Dinner));
                message.Append(". ");
            }
            message.Append("Please dont forget to vote for your favourite dishes to have your opinion counted!");

            await _notificationService.SendBatchNotifications(message.ToString(), AppConstants.Employee, (int)NotificationType.FoodItemVoting);
        }

        public async Task<string> PlanDailyMenu(string request)
        {
            var dailyMenuRequest = JsonSerializer.Deserialize<MenuInput>(request);

            if (await HasPlannedMenuForTomorrow())
            {
                throw new InvalidOperationException("Menu has already been planned for tomorrow.");
            }

            await ValidateFoodItemIds(dailyMenuRequest);

            await PlanMeal(dailyMenuRequest.Breakfast, MealType.Breakfast);
            await PlanMeal(dailyMenuRequest.Lunch, MealType.Lunch);
            await PlanMeal(dailyMenuRequest.Dinner, MealType.Dinner);
            await NotifyEmployeesForPlannedMenu(dailyMenuRequest);
            return "Notifications to vote for planned menu has been sent!";
        }

        public async Task<string> GetTopRecommendations()
        {
            var foodItems = await _foodItemService.GetTopRecommendationForChef();
            var recommendedItems = mapper.Map<List<RecommendedItem>>(foodItems);
            return JsonSerializer.Serialize(recommendedItems);
        }

        public async Task<string> GetEmployeeVotes()
        {
            if (!await HasPlannedMenuForTomorrow())
            {
                throw new InvalidOperationException("Menu has not yet planned,hence employee voting has not yet started");
            }

            Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date;
            var foodItems = await _weeklyMenuService.GetList<WeeklyMenu>("FoodItem, MealType", null, null, 10, 0, predicate);
            var foodItemDtos = foodItems.Select(fi => new EmployeeVotingView
            {
                Name = fi.FoodItem.Name,
                NumberOfVotes = fi.NumberOfVotes,
                MealType = fi.MealType.Name
            }).ToList();

            return JsonSerializer.Serialize(foodItemDtos);
        }

        public async Task ValidateFoodItemIds(MenuInput dailyMenuInput)
        {
            Expression<Func<FoodItem, bool>> predicate = foodItem => foodItem.StatusId == (int)Status.Available;

            var allAvailableFoodItems = await _foodItemService.GetList<FoodItem>(null, null, null, 0, 0, predicate);

            ValidateMealItems(dailyMenuInput.Breakfast, "Breakfast", allAvailableFoodItems);
            ValidateMealItems(dailyMenuInput.Lunch, "Lunch", allAvailableFoodItems);
            ValidateMealItems(dailyMenuInput.Dinner, "Dinner", allAvailableFoodItems);
        }

        private void ValidateMealItems(List<string> mealItems, string mealType, List<FoodItem> allAvailableFoodItems)
        {
            foreach (var itemId in mealItems.ToList())
            {
                if (!allAvailableFoodItems.Any(fi => fi.Id.ToString() == itemId))
                {
                    throw new FoodItemNotFoundException($"Invalid Food Item ID '{itemId}' provided for {mealType}.Food item is either unavailable or no such id exist");
                }
            }
        }

        private async Task<bool> HasPlannedMenuForTomorrow()
        {
            var today = DateTime.Today.Date;
            Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == today;
            var existingMenu = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate);

            return existingMenu.Any();
        }

        private async Task<bool> HasFinalisedMenuForTomorrow()
        {
            var today = DateTime.Today.Date;
            Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == today && data.IsSelected;
            var existingMenu = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate);

            return existingMenu.Any();
        }

        private async Task PlanMeal(List<string> mealItems, MealType mealType)
        {
            foreach (var item in mealItems)
            {
                var weeklyMenuRequest = new WeeklyMenuRequest
                {
                    FoodItemId = int.Parse(item),
                    MealTypeId = (int)mealType
                };
                await _weeklyMenuService.Add(weeklyMenuRequest);
            }
        }

        private async Task FinalizeMealItems(List<string> mealItems, MealType mealType)
        {
            foreach (var item in mealItems)
            {
                Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.FoodItemId == int.Parse(item);
                var mealItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();
                mealItem.IsSelected = true;
                await _weeklyMenuService.Update(mealItem.Id, mealItem);
            }
        }

        private async Task ValidateFoodItemsFromPlannedMenu(MenuInput dailyMenuRequest)
        {
            var mealTypes = new Dictionary<List<string>, MealType>
            {
                { dailyMenuRequest.Breakfast, MealType.Breakfast },
                { dailyMenuRequest.Lunch, MealType.Lunch },
                { dailyMenuRequest.Dinner, MealType.Dinner }
            };

            foreach (var (mealItems, mealType) in mealTypes)
            {
                foreach (var item in mealItems)
                {
                    int foodItemId = int.Parse(item);

                    Expression<Func<WeeklyMenu, bool>> predicate = menu =>
                        menu.FoodItemId == foodItemId &&
                        menu.MealTypeId == (int)mealType &&
                        menu.CreatedDateTime.Date == DateTime.Today.Date;

                    var menuEntry = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate);

                    if (menuEntry.Count == 0)
                    {
                        throw new InvalidOperationException($"Food item with ID {foodItemId} was not planned for {mealType} today.");
                    }
                }
            }
        }
    }
}
