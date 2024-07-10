using AutoMapper;
using CafeteriaRecommendationSystem.Services;
using CMS.Common.Models;
using CMS.Data.Entities;
using CMS.Data.Repository.Interfaces;
using CMS.Data.Services.Interfaces;
using Common;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.ML;
using System.Linq.Expressions;

namespace CMS.Data.Services
{
    public class FeedbackService : CrudBaseService<FoodItemFeedback>, IFeedbackService
    {
        private IMapper _mapper;
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(ICrudBaseRepository<FoodItemFeedback> repository, IMapper mapper, IFeedbackRepository feedbackRepository
            ) : base(repository, mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        

        public async Task SubmitDetailedFeedback(Common.Models.DetailedFeedback detailedFeedbackRequest)
        {
            DetailedFoodItemFeedback detailedFoodItemFeedback = _mapper.Map<DetailedFoodItemFeedback>(detailedFeedbackRequest);
            await _feedbackRepository.SubmitDetailedFeedback(detailedFoodItemFeedback);
        }

        
    }
}
