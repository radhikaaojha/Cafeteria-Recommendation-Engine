using CMS.Data.Entities;
using CMS.Data.Repository.Interfaces;
using Data_Access_Layer;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;

namespace CMS.Data.Repository
{
    public class FeedbackRepository : CrudBaseRepository<FoodItemFeedback>, IFeedbackRepository
    {
        public FeedbackRepository(CMSDbContext context) : base(context)
        {
        }

        public async Task SubmitDetailedFeedback(DetailedFoodItemFeedback detailedFoodItemFeedback)
        {
            _context.DetailedFoodItemFeedback.Add(detailedFoodItemFeedback);
            await _context.SaveChangesAsync();
        }
    }
}
