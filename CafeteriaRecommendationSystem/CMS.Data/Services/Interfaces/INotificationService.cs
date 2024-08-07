﻿using CafeteriaRecommendationSystem.Services;
using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface INotificationService : ICrudBaseService<Notification>
    {
        Task<List<Notification>> GetNotificationsForUser(int userId);
        Task<string> ViewNotifications(int userId);
        Task SendBatchNotifications(string message, List<int> roleId, int notificationTypeId);
        Task RemoveReadNotifications();
    }
}
