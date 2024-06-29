using AutoMapper;
using CMS.Common.Enums;
using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Common;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static TorchSharp.torch.nn;

namespace CMS.Data.Services
{
    public class AdminService : IAdminService
    {
        private IFoodItemService _foodItemService;
        private INotificationService _notificationService;
        private IUserRepository _userRepository;
        private IWeeklyMenuService _weeklyMenuService;

        public AdminService(INotificationService notificationService, IFoodItemService foodItemService, IUserRepository userRepository, IWeeklyMenuService weeklyMenuService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
            _weeklyMenuService = weeklyMenuService;
            _foodItemService = foodItemService;
        }

        public async Task<string> AddFoodItem(string input)
        {
            var foodItem = JsonSerializer.Deserialize<AddFoodItem>(input);

            if (await _foodItemService.DoesFoodItemWithSameNameExists(foodItem.Name))
            {
                return("Food item with the same name already exists!");
            }

            await _foodItemService.Add(foodItem);
            var notificationMessage = string.Format(AppConstants.FoodItemAdded, foodItem.Name);
            await _notificationService.SendBatchNotifications(notificationMessage, AppConstants.ChefAndEmployeeRoles,(int) NotificationType.NewFoodItemAdded);
            return $"Food item {foodItem.Name} added to menu successfully";
        }

        public async Task<string> UpdateAvailabilityStatusForFoodItem(string input)
        {
            var foodItemInput = JsonSerializer.Deserialize<FoodItemStatusUpdate>(input);
            var foodItem = await _foodItemService.UpdateStatus(foodItemInput.FoodItemId, foodItemInput.StatusId);
            var notificationMessage = string.Format(AppConstants.FoodItemStatusUpdated, foodItem.Name);
            await _notificationService.SendBatchNotifications(notificationMessage, AppConstants.ChefAndEmployeeRoles, (int)NotificationType.FoodItemAvailabilityUpdated);
            return $"Food item {foodItem.Name} status has been updated successfully";
        }

        public async Task<string> RemoveFoodItem(string request)
        {
            var foodItemId = JsonSerializer.Deserialize<int>(request);
            var foodItemInput = await _foodItemService.GetById<FoodItem>(foodItemId);
            var foodItem = await _foodItemService.UpdateStatus(foodItemInput.Id, (int)Status.Unavailable);
            var notificationMessage = string.Format(AppConstants.FoodItemRemoved, foodItem.Name);
            await _notificationService.SendBatchNotifications(notificationMessage, AppConstants.ChefAndEmployeeRoles, (int)NotificationType.FoodItemRemoved);
            return $"Food item {foodItem.Name} status has been discontinued successfully";
        }

        public async Task<string> UpdatePriceForFoodItem(string input)
        {
            var foodItemInput = JsonSerializer.Deserialize<FoodItemPriceUpdate>(input);
            var foodItem = await _foodItemService.UpdatePrice(foodItemInput.FoodItemId, foodItemInput.Price);
            var notificationMessage = string.Format(AppConstants.FoodItemPriceUpdated, foodItem.Name);
            await _notificationService.SendBatchNotifications(notificationMessage, AppConstants.ChefAndEmployeeRoles, (int)NotificationType.FoodItemPriceUpdated);
            return $"Food item {foodItem.Name} price has been updated successfully";
        }

        
    }
}
