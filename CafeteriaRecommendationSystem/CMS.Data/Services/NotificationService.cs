using CafeteriaRecommendationSystem.Services;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;

namespace CMS.Data.Services
{
    public class NotificationService : CrudBaseService<Notification>, INotificationService
    {
        private readonly IUserRepository _userRepository;
        public NotificationService(ICrudBaseRepository<Notification> repository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        public Task CleanupReadNotifications()
        {
            //base.UpdateRange(); CRON JOB? at eod
            throw new NotImplementedException();
        }

        public Task<List<Notification>> GetNotificationsForUser(int userId)
        {
            //base.GetList() WITH PREDICATE OF USERID
            //MarkNotificationsAsRead();
            throw new NotImplementedException();
        }

        public Task MarkNotificationsAsRead()
        {
            // isRead = true For userID AND BASE.UPDATE RANGE
            throw new NotImplementedException();
        }

        public Task SendBatchNotifications(string message, List<int> roleId)
        {
            //_userRepository.GetList() with predicate of role id
            //model for notification
            //base.AddRange(noti);
            throw new NotImplementedException();
        }
    }
}
