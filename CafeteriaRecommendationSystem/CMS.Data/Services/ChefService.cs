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
        private IFoodItemService _foodItemService;
        private INotificationService _notificationService;
        private IWeeklyMenuService _weeklyMenuService;
        private ISentimentAnalyzerService _sentimentAnalyzerService;
        private IMapper mapper;
        public ChefService(INotificationService notificationService,
            IFoodItemService foodItemService, IWeeklyMenuService weeklyMenuService,
            ISentimentAnalyzerService sentimentAnalyzerService,
            IMapper mapper)
        {
            _notificationService = notificationService;
            _foodItemService = foodItemService;
            _weeklyMenuService = weeklyMenuService;
            _sentimentAnalyzerService = sentimentAnalyzerService;
            this.mapper = mapper;
        }

        public async Task<string> FinalizeMenuItems(string finalisedMenuItemRequest)
        {
            var finalisedMenuItems = JsonSerializer.Deserialize<Menu>(finalisedMenuItemRequest);

            await ValidateFoodItemsForFinalMenu(finalisedMenuItems);

            await FinalizeFoodItems(finalisedMenuItems.Breakfast);
            await FinalizeFoodItems(finalisedMenuItems.Lunch);
            await FinalizeFoodItems(finalisedMenuItems.Dinner);

            await NotifyEmployeesForFinalizedMenu(finalisedMenuItems);

            return "Notifications for finalized menu has been sent successfully!";
        }

        public async Task NotifyEmployeesForFinalizedMenu(Menu finalMenu)
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

        public async Task NotifyEmployeesForPlannedMenu(Menu plannedMenu)
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

        public async Task<string> PlanMenuForNextDay(string plannedMenuItemRequest)
        {
            var plannedFoodItems = JsonSerializer.Deserialize<Menu>(plannedMenuItemRequest);

            await ValidateFoodItemsForPlannedMenu(plannedFoodItems);

            await PlanFoodItemsByMealType(plannedFoodItems.Breakfast, MealType.Breakfast);
            await PlanFoodItemsByMealType(plannedFoodItems.Lunch, MealType.Lunch);
            await PlanFoodItemsByMealType(plannedFoodItems.Dinner, MealType.Dinner);
            await NotifyEmployeesForPlannedMenu(plannedFoodItems);
            return "Notifications to vote for planned menu has been sent!";
        }

        public async Task<string> GetTopRecommendations()
        {
            var recommendedFoodItems = await _sentimentAnalyzerService.GetTopRecommendationForChef();
            var recommendedItemsDto = mapper.Map<List<RecommendedItem>>(recommendedFoodItems);
            return JsonSerializer.Serialize(recommendedItemsDto);
        }

        public async Task<string> GetEmployeeVotes()
        {
            if (!await HasPlannedMenuForTomorrow())
            {
                throw new InvalidOperationException("Menu has not yet planned,hence employee voting has not yet started");
            }

            Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date;
            var plannedFoodItemsWithVotes = await _weeklyMenuService.GetList<WeeklyMenu>("FoodItem, MealType", null, null, 0, 0, predicate);

            var plannedFoodItemsWithVotesDto = mapper.Map<List<FoodItemVotingStats>>(plannedFoodItemsWithVotes);

            return JsonSerializer.Serialize(plannedFoodItemsWithVotesDto);
        }

        public async Task ValidateFoodItemsForPlannedMenu(Menu plannedFoodItems)
        {
            if (await HasPlannedMenuForTomorrow())
            {
                throw new InvalidOperationException("Menu has already been planned for tomorrow.");
            }

            Expression<Func<FoodItem, bool>> predicate = foodItem => foodItem.StatusId == (int)Status.Available;

            var allAvailableFoodItems = await _foodItemService.GetList<FoodItem>(null, null, null, 0, 0, predicate);

            ValidateFoodItemsAvailability(plannedFoodItems.Breakfast, "Breakfast", allAvailableFoodItems);
            ValidateFoodItemsAvailability(plannedFoodItems.Lunch, "Lunch", allAvailableFoodItems);
            ValidateFoodItemsAvailability(plannedFoodItems.Dinner, "Dinner", allAvailableFoodItems);
        }

        private void ValidateFoodItemsAvailability(List<string> foodItems, string mealType, List<FoodItem> allAvailableFoodItems)
        {
            foreach (var itemId in foodItems.ToList())
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
            var plannedMenu = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate);

            return plannedMenu.Any();
        }

        private async Task<bool> HasFinalisedMenuForTomorrow()
        {
            var today = DateTime.Today.Date;
            Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == today && data.IsSelected;
            var finalisedMenu = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate);

            return finalisedMenu.Any();
        }

        private async Task PlanFoodItemsByMealType(List<string> foodItems, MealType mealType)
        {
            foreach (var item in foodItems)
            {
                var foodItem = new SelectedFoodItem
                {
                    FoodItemId = int.Parse(item),
                    MealTypeId = (int)mealType
                };
                await _weeklyMenuService.Add(foodItem);
            }
        }

        private async Task FinalizeFoodItems(List<string> foodItems)
        {
            foreach (var item in foodItems)
            {
                Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.FoodItemId == int.Parse(item);
                var foodItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();
                foodItem.IsSelected = true;
                await _weeklyMenuService.Update(foodItem.Id, foodItem);
            }
        }

        private async Task ValidateFoodItemsForFinalMenu(Menu finalisedMenuItems)
        {
            if (!await HasPlannedMenuForTomorrow())
            {
                throw new InvalidOperationException("Cannot finalise menu if not already planned for tomorrow.");
            }

            if (await HasFinalisedMenuForTomorrow())
            {
                throw new InvalidOperationException("Menu has already been finalised for tomorrow");
            }

            var mealTypes = new Dictionary<List<string>, MealType>
            {
                { finalisedMenuItems.Breakfast, MealType.Breakfast },
                { finalisedMenuItems.Lunch, MealType.Lunch },
                { finalisedMenuItems.Dinner, MealType.Dinner }
            };

            foreach (var (foodItems, mealType) in mealTypes)
            {
                foreach (var foodItem in foodItems)
                {
                    int foodItemId = int.Parse(foodItem);

                    Expression<Func<WeeklyMenu, bool>> predicate = menu =>
                        menu.FoodItemId == foodItemId &&
                        menu.MealTypeId == (int)mealType &&
                        menu.CreatedDateTime.Date == DateTime.Today.Date;

                    var plannedFoodItem = await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate);

                    if (plannedFoodItem.Count == 0)
                    {
                        throw new InvalidOperationException($"Food item with ID {foodItemId} was not planned for {mealType} today.");
                    }
                }
            }
        }
    }
}
