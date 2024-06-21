using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using System.Linq.Expressions;
using System.Text.Json;

namespace CMS.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IFeedbackService _feedbackService;
        private INotificationService _notificationService;
        private IWeeklyMenuService _weeklyMenuService;
        public EmployeeService(IFeedbackService feedbackService, INotificationService notificationService, IWeeklyMenuService weeklyMenuService)
        {
            _feedbackService = feedbackService;
            _notificationService = notificationService;
            _weeklyMenuService = weeklyMenuService;
        }


        public async Task<string> GiveFeedback(string request)
        {
            FeedbackRequest feedbackRequest = JsonSerializer.Deserialize<FeedbackRequest>(request);
            await _feedbackService.Add(feedbackRequest);
            return "Feedback added succesfully";
        }

        public async Task<string> VoteInFavourForMenuItem(string request)
        {
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
