﻿using AutoMapper;
using CafeteriaRecommendationSystem.Services;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System.Linq.Expressions;
using System.Text.Json;

namespace CMS.Data.Services
{
    public class NotificationService : CrudBaseService<Notification>, INotificationService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        public NotificationService(ICrudBaseRepository<Notification> repository, IUserRepository userRepository, IMapper mapper) : base(repository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> ViewNotifications(int userId)
        {
            var notificationDto = _mapper.Map<List<ViewNotification>>(await GetNotificationsForUser(userId));
            foreach (var notification in notificationDto)
            {
                notification.Message = FormatNotificationMessage(notification.Message);
            }
            return JsonSerializer.Serialize(notificationDto);
        }

        public async Task<List<Notification>> GetNotificationsForUser(int userId)
        {
            Expression<Func<Notification, bool>> predicate = data => data.UserId == userId && !data.IsRead;
            var notifications = await base.GetList<Notification>(null, null, null, 0, 0, predicate);
            if(notifications.Count != 0)
            {
                await MarkNotificationsAsRead(notifications);
            }           
            return notifications;
        }

        public async Task MarkNotificationsAsRead(List<Notification> notifications)
        {
            foreach(var notification in notifications)
            {
                notification.IsRead = true;
            }
            await base.UpdateRange(notifications);
        }

        public async Task SendBatchNotifications(string message, List<int> roleIds, int notificationTypeId)
        {
            Expression<Func<User, bool>> predicate = data => roleIds.Contains(data.RoleId);
            var users = await _userRepository.GetList(null,null,null,0,0,predicate);
            List<AddNotification> notifications = new();
            foreach(var user in users)
            {
                notifications.Add(new AddNotification
                {
                    Message = message,
                    IsRead = false,
                    UserId = user.Id,
                    NotificationTypeId = notificationTypeId
                });
            }
            await base.AddRange(notifications);
        }

        public async Task RemoveReadNotifications()
        {
            Expression<Func<Notification, bool>> predicate = n => n.IsRead == true;
            var readNotifications = await base.GetList<Notification>(null, null, null, 0, 0, predicate);

            await base.DeleteRange(readNotifications);
        }


        private string FormatNotificationMessage(string message)
        {
            return message.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
        }
    }
}
