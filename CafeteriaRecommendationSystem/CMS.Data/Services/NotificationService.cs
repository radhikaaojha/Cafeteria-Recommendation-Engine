using AutoMapper;
using CafeteriaRecommendationSystem.Services;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System.Linq.Expressions;

namespace CMS.Data.Services
{
    public class NotificationService : CrudBaseService<Notification>, INotificationService
    {
        private readonly IUserRepository _userRepository;
        public NotificationService(ICrudBaseRepository<Notification> repository, IUserRepository userRepository, IMapper mapper) : base(repository, mapper)
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

        public async Task SendBatchNotifications(string message, List<int> roleIds, int notificationTypeId)
        {
            Expression<Func<User, bool>> predicate = data => roleIds.Contains(data.RoleId);
            var users = await _userRepository.GetList(null,null,null,0,0,predicate);
            List<AddNotification> addNotifications = new();
            foreach(var user in users)
            {
                addNotifications.Add(new AddNotification
                {
                    Message = "New Food item added",
                    IsRead = false,
                    UserId = user.Id,
                    NotificationTypeId = 1
                });
            }
            await base.AddRange(addNotifications);
        }
    }
}
