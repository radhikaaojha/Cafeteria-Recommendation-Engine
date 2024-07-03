using AutoMapper;
using CafeteriaRecommendationSystem.Services;
using CMS.Common.Enums;
using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Repository.Interfaces;
using CMS.Data.Services.Interfaces;
using Common;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CMS.Data.Services
{
    public class FoodItemService : CrudBaseService<FoodItem>, IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly IAppActivityLogRepository _appActivityLogRepository;
        private readonly INotificationService _notificationService;
        private ILogger<FoodItemService> _logger;
        public FoodItemService(IFoodItemRepository foodItemRepository, ICrudBaseRepository<FoodItem> repository,
            IMapper mapper, ILogger<FoodItemService> logger,
            IAppActivityLogRepository appActivityLogRepository, INotificationService notificationService) : base(repository, mapper)
        {
            _foodItemRepository = foodItemRepository;
            _logger = logger;
            _notificationService = notificationService;
            _appActivityLogRepository = appActivityLogRepository;
        }

        public async Task<FoodItem> UpdatePrice(int foodItemId, decimal newPrice)
        {
            var foodItem = await base.GetById<FoodItem>(foodItemId);

            if (foodItem == null)
                throw new FoodItemNotFoundException("Food Item with given id doesnt exist", null, _logger);

            foodItem.Price = newPrice;
            await base.Update(foodItem.Id, foodItem);
            return foodItem;
        }

        public async Task<FoodItem> UpdateStatus(int foodItemId, int newStatusId)
        {
            var foodItem = await base.GetById<FoodItem>(foodItemId);

            if (foodItem == null)
                throw new FoodItemNotFoundException("Food Item with given id doesnt exist", null, _logger);

            foodItem.StatusId = newStatusId;
            await base.Update(foodItem.Id, foodItem);
            return foodItem;
        }

        public async Task<string> RemoveDiscardedFoodItem(string request)
        {
            var foodItemId = JsonSerializer.Deserialize<int>(request);

            if (await _appActivityLogRepository.HasTaskExecutedThisMonth("RemoveDiscardedFoodItem"))
                throw new InvalidOperationException("Discarded Food item can only be removed once a month.");

            var foodItem = await base.GetById<FoodItem>(foodItemId);

            if (foodItem == null)
                throw new FoodItemNotFoundException("Food Item with given id doesnt exist", null, _logger);

            if (foodItem.StatusId != (int)Status.Discarded)
                throw new FoodItemNotFoundException("Food Item doesnt exist in discarded list", null, _logger);

            foodItem.StatusId = (int)Status.Removed;
            await base.Update(foodItem.Id, foodItem);

            await _appActivityLogRepository.UpdateLastExecutionDate("RemoveDiscardedFoodItem", DateTime.Now);

            return $"Removed {foodItem.Name} successfully";
        }

        public async Task<bool> DoesFoodItemWithSameNameExists(string name)
        {
            return await _foodItemRepository.DoesFoodItemWithSameNameExists(name);
        }

        public async Task<List<FoodItem>> GetTopRecommendationForChef()
        {
            return await _foodItemRepository.GetNextDayMenuRecommendation();
        }

        public async Task UpdateSentimentResult(float score, string feedback, int foodItemId)
        {
            var foodItem = await base.GetById<FoodItem>(foodItemId);

            if (foodItem == null)
                throw new FoodItemNotFoundException("Food Item with given id doesnt exist", null, _logger);

            foodItem.SentimentScore = (decimal)score;
            foodItem.Description = feedback;
            await base.Update(foodItem.Id, foodItem);
        }

        public async Task<string> BrowseMenu()
        {
            var foodItems = await base.GetList<FoodItem>("FoodItemAvailabilityStatus, FoodItemType", null, null, 0, 0, null);
            var foodItemDtos = foodItems.Select(fi => new BrowseMenu
            {
                Id = fi.Id,
                Name = fi.Name,
                Price = fi.Price,
                AvailabilityStatus = fi.FoodItemAvailabilityStatus?.Name,
                FoodItemType = fi.FoodItemType?.Name,
                Description = fi.Description,
                SentimentScore = fi.SentimentScore
            }).ToList();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 128
            };
            return JsonSerializer.Serialize(foodItemDtos);
        }

        public async Task<string> ViewDiscardedFoodItem()
        {
            if (await _appActivityLogRepository.HasTaskExecutedThisMonth("GenerateDiscardList"))
            {
                throw new InvalidOperationException("Discarded Food items List can only be generated once a month.");
            }

            var discardedFoodItem = await _foodItemRepository.GetDiscardedFoodItem();

            var discardedFoodItemDto = new BrowseMenu
            {
                Id = discardedFoodItem.Id,
                Name = discardedFoodItem.Name,
                Price = discardedFoodItem.Price,
                AvailabilityStatus = discardedFoodItem.FoodItemAvailabilityStatus?.Name,
                FoodItemType = discardedFoodItem.FoodItemType?.Name,
                Description = discardedFoodItem.Description,
                SentimentScore = discardedFoodItem.SentimentScore
            };

            discardedFoodItem.StatusId = (int)Status.Discarded;
            await base.Update(discardedFoodItem.Id, discardedFoodItemDto);

            await _appActivityLogRepository.UpdateLastExecutionDate("GenerateDiscardList", DateTime.Now);

            return JsonSerializer.Serialize(discardedFoodItemDto);
        }

        public async Task<string> RollOutFeedbackQuestionnaireForDiscardedItem()
        {
            if (await _appActivityLogRepository.HasTaskExecutedThisMonth("DetailedFeedback"))
            {
                throw new InvalidOperationException("Detailed feedback has already been rolled out for this month.");
            }

            Expression<Func<FoodItem, bool>> predicate = data => data.StatusId == (int)Status.Discarded;

            var foodItems = await base.GetList<FoodItem>(null, null, new List<string> { "SentimentScore" }, 1, 0, predicate);

            if (foodItems.Count == 0)
                throw new InvalidOperationException("No discard item currently present,please generate discarded list");

            foreach (var foodItem in foodItems)
            {
                string message = $"We are trying to improve your experience with {foodItem.Name}.Id :{foodItem.Id} Please provide your feedback and help us." +
                                 $"Q1. What did you not like about {foodItem.Name}?" +
                                 $"Q2. How would you like {foodItem.Name} to taste?" +
                                 $"Q3. Share your moms recipe";
                await _notificationService.SendBatchNotifications(message.ToString(), AppConstants.Employee, (int)NotificationType.FinalMenu);
            }

            await _appActivityLogRepository.UpdateLastExecutionDate("DetailedFeedback", DateTime.Now);
            return "Detailed feedback questionnaire has been sent to all employees";
        }
        private bool ContainsNegativeKeywords(string feedback)
        {
            var negativeKeywords = new List<string> { "Tasteless", "extremely bad experience", "very poor", "bad", "disgusting", "not good", "gross", "poor" };

            foreach (var keyword in negativeKeywords)
            {
                if (feedback.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

