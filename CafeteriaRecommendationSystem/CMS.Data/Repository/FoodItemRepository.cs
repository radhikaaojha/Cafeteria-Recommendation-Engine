using CMS.Data.Repository.Interfaces;
using Common.Enums;
using Data_Access_Layer;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using System.Linq.Expressions;

namespace CMS.Data.Repository
{
    public class FoodItemRepository : CrudBaseRepository<FoodItem>, IFoodItemRepository
    {
        public FoodItemRepository(CMSDbContext context) : base(context)
        {
        }

        public async Task<bool> DoesFoodItemWithSameNameExists(string name)
        {
            return _context.FoodItem.Any(foodItem => foodItem.Name == name);
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

            return await base.GetList("FoodItemFeedback", null, new List<string> { "SentimentScore DESC" }, 5, 0, predicate);
        }

        public DateTime GetStartOfCurrentWeek()
        {
            DateTime now = DateTime.Now;
            int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;
            return now.AddDays(-1 * diff).Date;
        }
    }
}
