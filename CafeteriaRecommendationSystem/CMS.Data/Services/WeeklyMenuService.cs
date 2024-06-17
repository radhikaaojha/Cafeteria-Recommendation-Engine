using CafeteriaRecommendationSystem.Services;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services
{
    public class WeeklyMenuService : CrudBaseService<WeeklyMenu>, IWeeklyMenuService
    {
        private IFeedbackService _feedbackService;
        public WeeklyMenuService(ICrudBaseRepository<WeeklyMenu> repository, IFeedbackService feedbackService) : base(repository)
        {
            _feedbackService = feedbackService;
        }

        public Task CRONWeeklyMenuCleanUp()
        {
            throw new NotImplementedException();
        }

        public Task GetDailyMenu()
        {
            //another DTO for menu that has price, comment, rating
            //base.GetList() with predicate as todays date and shortlisted
            //list of food item ids
            //_feedbackService.GetAverageRatingByFoodItem(); for each food itrm
            // _feedbackService.AnalyzeFeedbackSentiments(fodItemId); 
            throw new NotImplementedException();
        }
    }
}
