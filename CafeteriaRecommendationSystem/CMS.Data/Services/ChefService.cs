using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ChefService(IFeedbackService feedbackService, INotificationService notificationService,
            IFoodItemService foodItemService, IWeeklyMenuService weeklyMenuService,
            IUserRepository userRepository) 
        {
            _feedbackService = feedbackService;
            _notificationService = notificationService;
            _foodItemService = foodItemService;
            _weeklyMenuService = weeklyMenuService;
            _userRepository = userRepository;
        }

        public Task FinalizeMenuItems()
        {
            //_weeklyMenuService.UpdateRange() set isShortlisted for date to true
            //NotifyEmployeesForFinalizeedMenu();
            throw new NotImplementedException();
        }

        public Task NotifyEmployeesForFinalizeedMenu()
        {
            //_notificationService.SendBatchNotifications(); to emp
            throw new NotImplementedException();
        }

        public Task NotifyEmployeesForPlannedMenu()
        {
            //_notificationService.SendBatchNotifications();
            throw new NotImplementedException();
        }

        public Task PlanDailyMenu()
        {
            //BrowseMenu();
           // _weeklyMenuService.Add(); further func for breakfast/lunch/dinner
           //NotifyEmployeesForPlannedMenu();
            throw new NotImplementedException();
        }

        public Task ViewFeedbackReport()
        {
           // _feedbackService.GetFeedbackReport();
            throw new NotImplementedException();
        }

        public Task ViewNotifications(int userId)
        {
            //_notificationService.GetNotificationsForUser(userId);
            throw new NotImplementedException();
        }

        Task IChefService.BrowseTodayMenu()
        {
            //_weeklyMenuService.GetDailyMenu();
            throw new NotImplementedException();
        }

        public void ViewFunctionalities()
        {
            //switch
            throw new NotImplementedException();
        }

        public Task BrowseMenu()
        {
            //_foodItemService.GetList() 
            throw new NotImplementedException();
        }
    }
}
