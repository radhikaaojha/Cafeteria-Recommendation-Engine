using CMS.Data.Services.Interfaces;

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

        public Task BrowseTodayMenu()
        {
            //_weeklyMenuService.GetDailyMenu();
            throw new NotImplementedException();
        }

        public Task GetVotingItems()
        {
            //_weeklyMenuService.GetList() todays date
            throw new NotImplementedException();
        }

        public Task GiveFeedback(int foodItemId, string feedback, int rating)
        {
            //model for feedback
            //_feedbackService.Add();
            throw new NotImplementedException();
        }

        public void ViewFunctionalities()
        {
            //switch menu
            throw new NotImplementedException();
        }

        public Task ViewNotifications(int userId)
        {
            //_notificationService.GetNotificationsForUser(userId);
            throw new NotImplementedException();
        }

        public Task VoteInFavourForMenuItem(int foodItemId)
        {
            //GetVotingItems();
            //in this list fetch the one having this food item id
            //for this record, increase num of votes
            //_weeklyMenuService.Update()
            throw new NotImplementedException();
        }


    }
}
