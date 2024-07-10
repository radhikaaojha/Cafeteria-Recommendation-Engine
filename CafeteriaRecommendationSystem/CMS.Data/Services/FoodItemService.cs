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
        private IMapper _mapper;
        public FoodItemService(IFoodItemRepository foodItemRepository, ICrudBaseRepository<FoodItem> repository,
            IMapper mapper, ILogger<FoodItemService> logger,
            IAppActivityLogRepository appActivityLogRepository, INotificationService notificationService) : base(repository, mapper)
        {
            _foodItemRepository = foodItemRepository;
            _logger = logger;
            _notificationService = notificationService;
            _appActivityLogRepository = appActivityLogRepository;
            _mapper = mapper;
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

        public async Task<string> RemoveDiscardedFoodItem(string discardedFoodItemId)
        {
            var foodItemId = JsonSerializer.Deserialize<int>(discardedFoodItemId);

            var foodItem = await ValidateRemovalOfDiscardedFoodItem(foodItemId);
            
            foodItem.StatusId = (int)Status.Removed;
            await base.Update(foodItem.Id, foodItem);

            await _appActivityLogRepository.UpdateLastExecutionDate("RemoveDiscardedFoodItem", DateTime.Now);

            return $"Removed {foodItem.Name} successfully";
        }

        public async Task<string> DiscardFoodItem(string discardFoodItemId)
        {
            var foodItemId = JsonSerializer.Deserialize<int>(discardFoodItemId);

            var foodItem = await ValidateDiscardingOfFoodItem(foodItemId);
           
            foodItem.StatusId = (int)Status.Discarded;
            await base.Update(foodItem.Id, foodItem);

            await _appActivityLogRepository.UpdateLastExecutionDate("DiscardFoodItem", DateTime.Now);

            return $"Discarded {foodItem.Name} successfully";
        }

        public async Task<bool> DoesFoodItemWithSameNameExists(string name)
        {
            return await _foodItemRepository.DoesFoodItemWithSameNameExists(name);
        }

        public async Task<string> ViewMenu()
        {
            var foodItemsList = await base.GetList<FoodItem>("FoodItemAvailabilityStatus, FoodItemType", null, null, 0, 0, null);
            var foodItems = _mapper.Map<List<ViewFoodItem>>(foodItemsList);
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 128
            };
            return JsonSerializer.Serialize(foodItems);
        }

        public async Task<string> GenerateDiscardedFoodItemList()
        {
            if (await _appActivityLogRepository.HasTaskExecutedThisMonth("GenerateDiscardList"))
            {
                throw new InvalidOperationException("Discarded Food items List can only be generated once a month.");
            }

            var discardedFoodItems = await _foodItemRepository.GetDiscardedFoodItems();

            var discardedFoodItemsList = _mapper.Map<List<ViewFoodItem>>(discardedFoodItems);

            await _appActivityLogRepository.UpdateLastExecutionDate("GenerateDiscardList", DateTime.Now);

            return JsonSerializer.Serialize(discardedFoodItemsList);
        }

        public async Task<string> RollOutFeedbackQuestionnaireForDiscardedItem()
        {
            if (await _appActivityLogRepository.HasTaskExecutedThisMonth("DetailedFeedback"))
            {
                throw new InvalidOperationException("Detailed feedback has already been rolled out for this month.");
            }

            Expression<Func<FoodItem, bool>> predicate = data => data.StatusId == (int)Status.Discarded && data.ModifiedDateTime.Month == DateTime.Now.Month && data.ModifiedDateTime.Year == DateTime.Now.Year; ;

            var foodItems = await base.GetList<FoodItem>(null, null, new List<string> { "SentimentScore" }, 1, 0, predicate);

            if (foodItems.Count == 0)
                throw new InvalidOperationException("No food item has been discarded yet!");

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

        private async Task<FoodItem> ValidateRemovalOfDiscardedFoodItem(int foodItemId)
        {
            if (await _appActivityLogRepository.HasTaskExecutedThisMonth("RemoveDiscardedFoodItem"))
                throw new InvalidOperationException("Discarded Food item can only be removed once a month.");

            var foodItem = await base.GetById<FoodItem>(foodItemId);

            if (foodItem == null)
                throw new FoodItemNotFoundException("Food Item with given id doesnt exist", null, _logger);

            if (foodItem.StatusId != (int)Status.Discarded)
                throw new FoodItemNotFoundException("Food Item is not yet discarded!", null, _logger);

            return foodItem;
        }

        private async Task<FoodItem> ValidateDiscardingOfFoodItem(int foodItemId)
        {
            if (!await _appActivityLogRepository.HasTaskExecutedThisMonth("GenerateDiscardList"))
                throw new InvalidOperationException("Discard food item list wasnt generated for this month.");

            if (await _appActivityLogRepository.HasTaskExecutedThisMonth("DiscardFoodItem"))
                throw new InvalidOperationException("We have already discarded a food item in this month.");

            var foodItem = await base.GetById<FoodItem>(foodItemId);

            if (foodItem == null)
                throw new FoodItemNotFoundException("Food Item with given id doesnt exist", null, _logger);

            return foodItem;
        }
    }
}

