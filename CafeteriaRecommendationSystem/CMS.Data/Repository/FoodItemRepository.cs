using CMS.Data.Repository.Interfaces;
using Common.Enums;
using Data_Access_Layer;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using System.Linq.Expressions;
using Common.Enums;
using FoodItemType = Common.Enums.FoodItemType;

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

        public async Task<List<FoodItem>> GetNextDayMenuRecommendation()
        {
            DateTime startOfWeek = GetStartOfCurrentWeek();
            DateTime endOfWeek = startOfWeek.AddDays(7);
            Expression<Func<FoodItem, bool>> predicate = foodItem =>
                       foodItem.StatusId == (int)Status.Available &&
                       !_context.WeeklyMenu.Any(weeklyMenu =>
                           weeklyMenu.FoodItemId == foodItem.Id &&
                           weeklyMenu.IsSelected &&
                           weeklyMenu.CreatedDateTime.Date >= startOfWeek && weeklyMenu.CreatedDateTime.Date < endOfWeek);

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
            var combinedOptions = mainCourseOptions.Concat(otherItemOptions).ToList();

            return combinedOptions;
        }

        public DateTime GetStartOfCurrentWeek()
        {
            DateTime now = DateTime.Now;
            int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
            return now.AddDays(-1 * diff).Date;
        }
    }
}
