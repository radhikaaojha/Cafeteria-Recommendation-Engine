using AutoMapper;
using CafeteriaRecommendationSystem.Services;
using CMS.Common.Models;
using CMS.Common.Utils;
using CMS.Data.Repository.Interfaces;
using CMS.Data.Services.Interfaces;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<List<RecommendedItem>> GetTopRecommendationForChef()
        {
            Expression<Func<FoodItem, bool>> predicate = data => data.StatusId == (int)Status.Available;
            var foodItems = await base.GetList<FoodItem>("FoodItemFeedback", null, null, 0, 0, predicate);
            List<RecommendedItem> recommendedItemList = new();
            foreach(var foodItem in foodItems)
            {
                RecommendedItem recommendedItem = new();
                recommendedItem.Name = foodItem.Name;

                var feedbackComments = foodItem.FoodItemFeedback.Select(f => f.Comment);
                string input = string.Join(". ", feedbackComments);
                var sentiment = RecommendationEngine.GetSentiments(input);

                recommendedItem.Description = sentiment;

                recommendedItem.SentimentScore = (decimal)RecommendationEngine.AnalyzeSentimentScore(sentiment);

                recommendedItemList.Add(recommendedItem);
            }

            var sortedItems = recommendedItemList.OrderByDescending(r => r.SentimentScore).ToList();

            return sortedItems;
        }


    }
}
