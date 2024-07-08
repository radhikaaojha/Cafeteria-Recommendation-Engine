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

        public async Task<List<FoodItem>> GetNextDayMenuRecommendation()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Expression<Func<FoodItem, bool>> predicate = foodItem =>
                       foodItem.StatusId == (int)Status.Available &&
                       !_context.WeeklyMenu.Any(weeklyMenu =>
                           weeklyMenu.FoodItemId == foodItem.Id &&
                           weeklyMenu.IsSelected && weeklyMenu.CreatedDateTime.Date != yesterday);

            var allAvailableFoodItems  = await base.GetList("FoodItemFeedback", null, new List<string> { "SentimentScore DESC" }, 15, 0, predicate);
            var mainCourseOptions = allAvailableFoodItems.Where(fi => fi.FoodItemTypeId == (int)FoodItemType.MainCourses).Take(5).ToList();
            var otherItemOptions = allAvailableFoodItems
                                   .Where(fi => fi.FoodItemTypeId != (int)FoodItemType.MainCourses)
                                   .GroupBy(fi => fi.FoodItemTypeId)
                                   .SelectMany(g => g.Take(2))
                                   .Take(10)
                                   .ToList();
            if (otherItemOptions.Count < 10)
            {
                otherItemOptions.AddRange(
                    allAvailableFoodItems
                    .Except(mainCourseOptions)
                    .Except(otherItemOptions)
                    .Take(10 - otherItemOptions.Count)
                );
            }
            var combinedOptions = mainCourseOptions.Concat(otherItemOptions).OrderByDescending(u=>u.SentimentScore).ToList();

            return combinedOptions;
        }
        private bool ContainsNegativeKeywords(string description)
        {
            List<string> negativeKeywords = AppConstants.NegativeKeywords;
            return negativeKeywords.Any(keyword => description.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
