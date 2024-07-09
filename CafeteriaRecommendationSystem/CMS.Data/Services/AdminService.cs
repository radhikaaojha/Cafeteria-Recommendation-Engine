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

        public async Task<string> AddFoodItem(string foodItemRequest)
        {
            var addFoodItemRequestModel = JsonSerializer.Deserialize<AddFoodItem>(foodItemRequest);

            await ValidateAddFoodItemRequest(addFoodItemRequestModel);

            await _foodItemService.Add(addFoodItemRequestModel);

            await NotifyForUpdate((int)NotificationType.NewFoodItemAdded, addFoodItemRequestModel.Name);

            return $"Food item {addFoodItemRequestModel.Name} added to menu successfully";
        }

        public async Task<string> UpdateAvailabilityStatusForFoodItem(string updateFoodItemStatusRequest)
        {
            var updateFoodItemStatusModel = JsonSerializer.Deserialize<UpdateFoodItemStatus>(updateFoodItemStatusRequest);

            await ValidateUpdateStatusRequest(updateFoodItemStatusModel);
            
            var foodItem = await _foodItemService.UpdateStatus(updateFoodItemStatusModel.FoodItemId, updateFoodItemStatusModel.StatusId);

            await NotifyForUpdate((int)NotificationType.FoodItemAvailabilityUpdated, foodItem.Name);

            return $"Food item {foodItem.Name} status has been updated successfully";
        }

        public async Task<string> RemoveFoodItem(string removeFoodItemRequest)
        {
            var foodItemId = JsonSerializer.Deserialize<int>(removeFoodItemRequest);

            var foodItem = await _foodItemService.UpdateStatus(foodItemId, (int)Status.Removed);

            await NotifyForUpdate((int)NotificationType.FoodItemRemoved, foodItem.Name);

            return $"Food item {foodItem.Name} status has been discontinued successfully";
        }

        public async Task<string> UpdatePriceForFoodItem(string updateFoodItemPriceRequest)
        {
            var updateFoodItemPriceRequestModel = JsonSerializer.Deserialize<UpdateFoodItemPrice>(updateFoodItemPriceRequest);

            await ValidateUpdatePriceRequest(updateFoodItemPriceRequestModel);
            
            var foodItem = await _foodItemService.UpdatePrice(updateFoodItemPriceRequestModel.FoodItemId, updateFoodItemPriceRequestModel.Price);

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

        private async Task ValidateAddFoodItemRequest(AddFoodItem addFoodItemRequestModel)
        {
            if (!addFoodItemRequestModel.IsValid())
            {
                throw new InvalidInputException("Invalid food item data provided!", null, _logger);
            }

            if (await _foodItemService.DoesFoodItemWithSameNameExists(addFoodItemRequestModel.Name))
            {
                throw new FoodItemExistsException("Food item with the same name already exists!", null, _logger);
            }
        }
        private async Task ValidateUpdateStatusRequest(UpdateFoodItemStatus updateFoodItemStatusModel)
        {
            if (!Enum.IsDefined(typeof(Status), updateFoodItemStatusModel.StatusId))
            {
                throw new InvalidInputException($"Invalid status ID: {updateFoodItemStatusModel.StatusId}.", null, _logger);
            }
        }
        private async Task ValidateUpdatePriceRequest(UpdateFoodItemPrice updateFoodItemPriceRequestModel)
        {
            if (!updateFoodItemPriceRequestModel.IsValid())
            {
                throw new InvalidInputException("Food item price must be greater than 0!", null, _logger);
            }
        }
    }
}
