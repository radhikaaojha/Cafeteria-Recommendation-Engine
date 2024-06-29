using AutoMapper;
using CafeteriaRecommendationSystem.Services;
using CMS.Common.Models;
using CMS.Data.Repository.Interfaces;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CMS.Data.Services
{
    public class FoodItemService : CrudBaseService<FoodItem>, IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;
        public FoodItemService(IFoodItemRepository foodItemRepository, ICrudBaseRepository<FoodItem> repository, IMapper mapper) : base(repository, mapper)
        {
            _foodItemRepository = foodItemRepository;
        }

        public async Task<FoodItem> UpdatePrice(int foodItemId, decimal newPrice)
        {
            var foodItem = await base.GetById<FoodItem>(foodItemId);
            foodItem.Price = newPrice;
            await base.Update(foodItem.Id, foodItem);
            return foodItem;
        }

        public async Task<FoodItem> UpdateStatus(int foodItemId, int newStatusId)
        {
            var foodItem = await base.GetById<FoodItem>(foodItemId);
            foodItem.StatusId = newStatusId;
            await base.Update(foodItem.Id, foodItem);
            return foodItem;
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
    }
}
