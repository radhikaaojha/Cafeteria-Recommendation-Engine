using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Microsoft.ML;
using System.Linq.Expressions;
using System.Text.Json;

namespace CMS.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IFeedbackService _feedbackService;
        private INotificationService _notificationService;
        private IWeeklyMenuService _weeklyMenuService;
        private IFoodItemService _foodItemService;
        public EmployeeService(IFeedbackService feedbackService, INotificationService notificationService, IWeeklyMenuService weeklyMenuService, IFoodItemService foodItemService)
        {
            _feedbackService = feedbackService;
            _notificationService = notificationService;
            _weeklyMenuService = weeklyMenuService;
            _foodItemService = foodItemService;
        }


        public async Task<string> GiveFeedback(string request)
        {
            //only for items made today
            FeedbackRequest feedbackRequest = JsonSerializer.Deserialize<FeedbackRequest>(request);
            await _feedbackService.Add(feedbackRequest);
            var (rating, feedbacks) = await _feedbackService.AnalyzeFeedbackSentiments(feedbackRequest.FoodItemId);
            await _foodItemService.UpdateSentimentResult(rating, feedbacks, feedbackRequest.FoodItemId);
            return "Feedback added succesfully";
        }

        public async Task<string> ViewNextDayMenu()
        {
            Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.IsSelected;
            var weeklyMenuItems = await _weeklyMenuService.GetList<WeeklyMenu>("FoodItem", null, null, 0, 0, predicate);
            var groupedItems = weeklyMenuItems.GroupBy(u => u.MealTypeId);

            var viewNextDayMenu = new ViewNextDayMenu();

            foreach (var group in groupedItems)
            {
                var foodItems = group.Select(u => new RecommendedItem
                {
                    Id = u.FoodItem.Id,
                    Name = u.FoodItem.Name,
                    Description = u.FoodItem.Description,
                    SentimentScore = u.FoodItem.SentimentScore
                }).ToList();

                switch (group.Key)
                {
                    case 1:
                        viewNextDayMenu.Breakfast.AddRange(foodItems);
                        break;
                    case 2:
                        viewNextDayMenu.Lunch.AddRange(foodItems);
                        break;
                    case 3:
                        viewNextDayMenu.Dinner.AddRange(foodItems);
                        break;
                    default:
                        break;
                }
            }

            return JsonSerializer.Serialize(viewNextDayMenu);
        }

        public async Task<string> VoteInFavourForMenuItem(string request)
        {
            //make sure they dont vote againtt
            var dailyMenuRequest = JsonSerializer.Deserialize<DailyMenuInput>(request);
            foreach (var item in dailyMenuRequest.Breakfast)
            {
                Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.FoodItemId == int.Parse(item);
                var breakfastItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();
                breakfastItem.NumberOfVotes += 1;
                await _weeklyMenuService.Update(breakfastItem.Id, breakfastItem);
            }
            foreach (var item in dailyMenuRequest.Lunch)
            {
                Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.FoodItemId == int.Parse(item);
                var lunchItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();
                lunchItem.NumberOfVotes += 1;
                await _weeklyMenuService.Update(lunchItem.Id, lunchItem);
            }
            foreach (var item in dailyMenuRequest.Dinner)
            {
                Expression<Func<WeeklyMenu, bool>> predicate = data => data.CreatedDateTime.Date == DateTime.Now.Date && data.FoodItemId == int.Parse(item);
                var dinnerItem = (await _weeklyMenuService.GetList<WeeklyMenu>(null, null, null, 1, 0, predicate))
                        .FirstOrDefault();
                dinnerItem.NumberOfVotes += 1;
                await _weeklyMenuService.Update(dinnerItem.Id, dinnerItem);
            }
            return "Voting has been submitted sucessfully!";
        }
    }
}
