using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Models;
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
        Task<(float, string)> AnalyzeFeedbackSentiments(int foodItemId);
        Task SubmitDetailedFeedback(DetailedFeedbackRequest detailedFeedbackRequest);
    }
}
