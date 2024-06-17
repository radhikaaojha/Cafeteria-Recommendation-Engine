using CafeteriaRecommendationSystem.Services;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CMS.Data.Services
{
    public class FeedbackService : CrudBaseService<FoodItemFeedback>, IFeedbackService
    {
        public FeedbackService(ICrudBaseRepository<FoodItemFeedback> repository) : base(repository)
        {
        }

        public Task AnalyzeFeedbackSentiments(int foodItemId)
        {
            //base.GetList() where food item is this
            //analaysze
            throw new NotImplementedException();
        }

        public Task<double> GetAverageRatingByFoodItem(int foodItemId)
        {
            //base.GetList(); Predicate=fooitemid
            //avg of ratin
            throw new NotImplementedException();
        }

        public Task GetFeedbackReport(DateTime startDate, DateTime endDate)
        {
            //base.GetList() pred=endDate start
            //analyse sentiments for each food item
            //avg rating for each food item
            throw new NotImplementedException();
        }
    }
}
