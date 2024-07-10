using CMS.Data.Repository.Interfaces;
using Common.Enums;
using Data_Access_Layer;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using System.Linq.Expressions;
using Common.Enums;
using FoodItemType = Common.Enums.FoodItemType;
using Microsoft.EntityFrameworkCore;
using CMS.Common.Exceptions;
using Common;

namespace CMS.Data.Repository
{
    public class FoodItemRepository : CrudBaseRepository<FoodItem>, IFoodItemRepository
    {
        public FoodItemRepository(CMSDbContext context) : base(context)
        {
        }

        public async Task<bool> DoesFoodItemWithSameNameExists(string name)
        {
            return _context.FoodItem.Any(foodItem => foodItem.Name.ToLower() == name.ToLower());
        }
        
        public async Task<List<FoodItem>> GetDiscardedFoodItems()
        {
            var foodItems = await _context.FoodItem.Include(f => f.FoodItemAvailabilityStatus)
                                                   .Include(f => f.FoodItemType)
                                                   .Where(f => f.SentimentScore < 20 && f.StatusId == (int) Status.Available)
                                                   .OrderBy(f => f.SentimentScore)
                                                   .ToListAsync();

            var discardedFoodItems = foodItems.Where(f => ContainsNegativeKeywords(f.Description)).ToList();

            if (discardedFoodItems.Count() == 0)
                throw new FoodItemNotFoundException("No food item elgibile for discard menu item list");

            return discardedFoodItems;
        }

        private bool ContainsNegativeKeywords(string description)
        {
            List<string> negativeKeywords = AppConstants.NegativeKeywords;
            return negativeKeywords.Any(keyword => description.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
