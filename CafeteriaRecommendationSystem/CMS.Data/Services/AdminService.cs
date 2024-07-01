using AutoMapper;
using CMS.Common.Enums;
using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Common;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tensorflow;
using static TorchSharp.torch.nn;
using Status = Common.Enums.Status;

namespace CMS.Data.Services
{
    public class AdminService : IAdminService
    {
        private IFoodItemService _foodItemService;
        private INotificationService _notificationService;
        private IUserRepository _userRepository;
        private IWeeklyMenuService _weeklyMenuService;
        private ILogger<AdminService> _logger;

        public AdminService(INotificationService notificationService, IFoodItemService foodItemService, IUserRepository userRepository, IWeeklyMenuService weeklyMenuService, ILogger<AdminService> logger)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
            _weeklyMenuService = weeklyMenuService;
            _foodItemService = foodItemService;
            _logger = logger;
        }

        public async Task<string> AddFoodItem(string input)
        {
            var foodItem = JsonSerializer.Deserialize<AddFoodItem>(input);

            if (!foodItem.IsValid())
            {
                throw new InvalidInputException("Invalid food item data provided!", null, _logger);
            }

            if (await _foodItemService.DoesFoodItemWithSameNameExists(foodItem.Name))
            {
                throw new FoodItemExistsException("Food item with the same name already exists!",null,_logger);
            }

            await _foodItemService.Add(foodItem);

            await NotifyForUpdate((int)NotificationType.NewFoodItemAdded, foodItem.Name);

            return $"Food item {foodItem.Name} added to menu successfully";
        }

        public async Task<string> UpdateAvailabilityStatusForFoodItem(string input)
        {
            var foodItemInput = JsonSerializer.Deserialize<FoodItemStatusUpdate>(input);

            if (!Enum.IsDefined(typeof(Status), foodItemInput.StatusId))
            {
                throw new InvalidInputException($"Invalid status ID: {foodItemInput.StatusId}.", null, _logger);
            }

            var foodItem = await _foodItemService.UpdateStatus(foodItemInput.FoodItemId, foodItemInput.StatusId);

            await NotifyForUpdate((int)NotificationType.FoodItemAvailabilityUpdated, foodItem.Name);

            return $"Food item {foodItem.Name} status has been updated successfully";
        }

        public async Task<string> RemoveFoodItem(string request)
        {
            var foodItemId = JsonSerializer.Deserialize<int>(request);

            var foodItem = await _foodItemService.UpdateStatus(foodItemId, (int)Status.Removed);

            await NotifyForUpdate((int)NotificationType.FoodItemRemoved, foodItem.Name);

            return $"Food item {foodItem.Name} status has been discontinued successfully";
        }

        public async Task<string> UpdatePriceForFoodItem(string input)
        {
            var foodItemInput = JsonSerializer.Deserialize<FoodItemPriceUpdate>(input);

            if (!foodItemInput.IsValid())
            {
                throw new InvalidInputException("Food item price must be greater than 0!", null, _logger);
            }

            var foodItem = await _foodItemService.UpdatePrice(foodItemInput.FoodItemId, foodItemInput.Price);

            await NotifyForUpdate((int)NotificationType.FoodItemPriceUpdated, foodItem.Name);

            return $"Food item {foodItem.Name} price has been updated successfully";
        }

        public async Task NotifyForUpdate(int notificationTypeId, string itemName)
        {
            var notificationMessage = GenerateNotificationMessage(notificationTypeId, itemName);
            await SendBatchNotifications(notificationMessage, notificationTypeId);
        }

        private string GenerateNotificationMessage(int notificationTypeId, string itemName)
        {
            string notificationMessage = string.Empty;

            switch ((NotificationType)notificationTypeId)
            {
                case NotificationType.NewFoodItemAdded:
                    notificationMessage = string.Format(AppConstants.FoodItemAdded, itemName);
                    break;
                case NotificationType.FoodItemRemoved:
                    notificationMessage = string.Format(AppConstants.FoodItemRemoved, itemName);
                    break;
                case NotificationType.FoodItemPriceUpdated:
                    notificationMessage = string.Format(AppConstants.FoodItemPriceUpdated, itemName);
                    break;
                case NotificationType.FoodItemAvailabilityUpdated:
                    notificationMessage = string.Format(AppConstants.FoodItemStatusUpdated, itemName);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(notificationTypeId), $"Unsupported notification type ID: {notificationTypeId}");
            }

            return notificationMessage;
        }

        private async Task SendBatchNotifications(string notificationMessage,int notificationTypeId)
        {
            await _notificationService.SendBatchNotifications(notificationMessage, AppConstants.ChefAndEmployeeRoles, notificationTypeId);
        }

    }
}
