using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IFeedbackService : ICrudBaseService<FoodItemFeedback>
    {
        Task<double> GetAverageRatingByFoodItem(int foodItemId);
        Task AnalyzeFeedbackSentiments(int foodItemId);
        Task GetFeedbackReport(DateTime startDate, DateTime endDate);
    }
}
