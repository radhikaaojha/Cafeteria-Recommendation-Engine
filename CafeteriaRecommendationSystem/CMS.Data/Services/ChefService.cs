using AutoMapper;
using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Enums;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Common;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
            var dailyMenuRequest = JsonSerializer.Deserialize<DailyMenuInput>(request);
            foreach (var item in dailyMenuRequest.Breakfast)
            {
                Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.FoodItemId == int.Parse(item);
                var breakfastItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();
                breakfastItem.IsSelected = true;
                await _weeklyMenuService.Update(breakfastItem.Id,breakfastItem);
            }
            foreach (var item in dailyMenuRequest.Lunch)
            {
                Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.FoodItemId == int.Parse(item);
                var lunchItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();
                lunchItem.IsSelected = true;
                await _weeklyMenuService.Update(lunchItem.Id, lunchItem);
            }
            foreach (var item in dailyMenuRequest.Dinner)
            {
                Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.FoodItemId == int.Parse(item);
                var dinnerItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();
                dinnerItem.IsSelected = true;
                await _weeklyMenuService.Update(dinnerItem.Id, dinnerItem);
            }
            await NotifyEmployeesForPlannedMenu(dailyMenuRequest);
            return "Notifications for finalized menu has been sent successfully!";
        }

        public async Task NotifyEmployeesForFinalizeedMenu(DailyMenuInput finalMenu)
        {
            /*var message = new System.Text.StringBuilder();
            message.AppendLine("The final menu for tomorrow has been finalized!");
            if (finalMenu.Breakfast.Count > 0)
            {
                message.AppendLine("\nThe following items are decided to be made for breakfast:");
                message.AppendLine(string.Join(", ", finalMenu.Breakfast));
                message.AppendLine();
            }

            if (finalMenu.Lunch.Count > 0)
            {
                message.AppendLine("\nThe following items are decided to be made for lunch:");
                message.AppendLine(string.Join(", ", finalMenu.Lunch));
                message.AppendLine();
            }

            if (finalMenu.Dinner.Count > 0)
            {
                message.AppendLine("\nThe following items are decided to be made for dinner:");
                message.AppendLine(string.Join(", ", finalMenu.Dinner));
                message.AppendLine();
            }*/
            var finalMenuNotification = new DisplayMenu
            {
                Breakfast = finalMenu.Breakfast,
                Lunch = finalMenu.Lunch,
                Dinner = finalMenu.Dinner,
                Message = "Finalized Menu for tomoroorw is here!"
            };
            string jsonMessage = JsonSerializer.Serialize(finalMenuNotification);

            await _notificationService.SendBatchNotifications(jsonMessage.ToString(), AppConstants.Employee, (int)NotificationType.FinalMenu);
        }

        public async Task NotifyEmployeesForPlannedMenu(DailyMenuInput plannedMenu)
        {
            /* var message = new System.Text.StringBuilder();
             if (plannedMenu.Breakfast.Count > 0)
             {
                 message.AppendLine("The following items are decided to be made for breakfast:");
                 message.AppendLine(string.Join(", ", plannedMenu.Breakfast));
                 message.AppendLine();
             }

             if (plannedMenu.Lunch.Count > 0)
             {
                 message.AppendLine("The following items are decided to be made for lunch:");
                 message.AppendLine(string.Join(", ", plannedMenu.Lunch));
                 message.AppendLine();
             }

             if (plannedMenu.Dinner.Count > 0)
             {
                 message.AppendLine("The following items are decided to be made for dinner:");
                 message.AppendLine(string.Join(", ", plannedMenu.Dinner));
                 message.AppendLine();
             }
             message.AppendLine("Please don't forget to vote for your favourite dishes to have your opinion counted!");*/
            var plannedMenuNotification = new DisplayMenu
            {
                Breakfast = plannedMenu.Breakfast,
                Lunch = plannedMenu.Lunch,
                Dinner = plannedMenu.Dinner,
                Message = "Finalized Menu for tomoroorw is here!"
            };
            string jsonMessage = JsonSerializer.Serialize(plannedMenuNotification);

            await _notificationService.SendBatchNotifications(jsonMessage.ToString(), AppConstants.Employee, (int)NotificationType.FoodItemVoting);
        }

        public async Task<string> PlanDailyMenu(string request)
        {
            var dailyMenuRequest = JsonSerializer.Deserialize<DailyMenuInput>(request);
            foreach(var item in dailyMenuRequest.Breakfast)
            {
                var weeklyMenuRequest = new WeeklyMenuRequest
                {
                    FoodItemId = int.Parse(item),
                    MealTypeId = 1
                };
                await _weeklyMenuService.Add(weeklyMenuRequest);
            }
            foreach (var item in dailyMenuRequest.Lunch)
            {
                var weeklyMenuRequest = new WeeklyMenuRequest
                {
                    FoodItemId = int.Parse(item),
                    MealTypeId = 2
                };
                await _weeklyMenuService.Add(weeklyMenuRequest);
            }
            foreach (var item in dailyMenuRequest.Dinner)
            {
                var weeklyMenuRequest = new WeeklyMenuRequest
                {
                    FoodItemId = int.Parse(item),
                    MealTypeId = 3
                };
                await _weeklyMenuService.Add(weeklyMenuRequest);
            }
            await NotifyEmployeesForPlannedMenu(dailyMenuRequest);
            return "Notifications to vote for planned menu has been sent!";
        }

        public async Task<string> ViewNotifications(int userId)
        {
            var notificationModel = mapper.Map<List<ViewNotification>>(await _notificationService.GetNotificationsForUser(userId));
            return JsonSerializer.Serialize(notificationModel);
        }

        public async Task<string> GetTopRecommendations()
        {
            var foodItems = await _foodItemService.GetTopRecommendationForChef();        
            var recommendedItems = mapper.Map<List<RecommendedItem>>(foodItems);
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 128
            };
            return JsonSerializer.Serialize(recommendedItems);
        }

        public async Task<string> GetEmployeeVotes()
        {
            Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date;
            var foodItems = await _weeklyMenuService.GetList<WeeklyMenu>("FoodItem, MealType", null, null, 10, 0, predicate);
            var foodItemDtos = foodItems.Select(fi => new EmployeeVotingView
            {
                Name = fi.FoodItem.Name,
                NumberOfVotes = fi.NumberOfVotes,
                MealType = fi.MealType.Name
            }).ToList();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 128
            };
            return JsonSerializer.Serialize(foodItemDtos);
        }
    }
}
