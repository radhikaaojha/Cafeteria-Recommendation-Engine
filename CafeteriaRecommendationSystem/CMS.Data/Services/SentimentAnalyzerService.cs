using AutoMapper;
using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Repository.Interfaces;
using CMS.Data.Services.Interfaces;
using Common;
using Data_Access_Layer.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services
{
    public class SentimentAnalyzerService : ISentimentAnalyzerService
    {
        private ISentimentAnalyzerRepository _sentimentAnalyzerRepository;
        private IMapper _mapper;
        private IFeedbackService _feedbackService;
        private IFoodItemService _foodItemService;
        private ILogger<SentimentAnalyzerService> _logger;
        public SentimentAnalyzerService(ISentimentAnalyzerRepository sentimentAnalyzerRepository, IMapper mapper, ILogger<SentimentAnalyzerService> logger, IFeedbackService feedbackService,
            IFoodItemService foodItemService) 
        {
            _mapper = mapper;
            _logger = logger;
            _sentimentAnalyzerRepository = sentimentAnalyzerRepository;
            _foodItemService = foodItemService;
            _feedbackService = feedbackService;
        }

        public async Task<List<FoodItem>> GetTopRecommendationForChef()
        {
            return await _sentimentAnalyzerRepository.GetNextDayMenuRecommendation();
        }

        public async Task UpdateSentimentAnalysis(Feedback feedbackRequest)
        {
            var (rating, feedbacks) = await AnalyzeFeedbackSentiments(feedbackRequest.FoodItemId);
            await UpdateSentimentResult(rating, feedbacks, feedbackRequest.FoodItemId);
        }

        private async Task<(float, string)> AnalyzeFeedbackSentiments(int foodItemId)
        {
            var foodReviews = await GetFeedbackListForFoodItem(foodItemId);
           
            var predictor = TrainModel();

            var sentiments = foodReviews.Select(review => new
            {
                Review = review,
                Prediction = predictor.Predict(review)
            }).ToList();

            var foodItemReview = sentiments.Select(g => g.Review.ReviewText).ToList();

            var foodItemAverageProbaility = sentiments.Average(g => g.Prediction.Probability) * 100;

            var majorSentiments = ExtractMajorSentiments(foodItemReview, sentiments.Select(g => g.Prediction).ToList());

            var foodItemSentimentSummary = (string.Join(", ", majorSentiments));

            return (foodItemAverageProbaility, foodItemSentimentSummary);

        }

        private async Task<List<FoodReview>> GetFeedbackListForFoodItem(int foodItemId)
        {
            Expression<Func<FoodItemFeedback, bool>> predicate = data => data.FoodItemId == foodItemId;
            var feedbacksList = await _feedbackService.GetList<FoodItemFeedback>(null, null, null, 0, 0, predicate);
            return _mapper.Map<List<FoodReview>>(feedbacksList);
        }

        private PredictionEngine<FoodReview, SentimentPrediction> TrainModel()
        {
            var context = new MLContext();
            string dataPath = AppConstants.DataPathForTrainedModel;
            var data = context.Data.LoadFromTextFile<FoodReview>(dataPath, separatorChar: ',', hasHeader: true);
            var pipeline = context.Transforms.Text.FeaturizeText("Features", nameof(FoodReview.ReviewText)).Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Sentiment", featureColumnName: "Features"));
            var model = pipeline.Fit(data);
            return context.Model.CreatePredictionEngine<FoodReview, SentimentPrediction>(model);
        }

        private async Task UpdateSentimentResult(float score, string feedback, int foodItemId)
        {
            var foodItem = await _foodItemService.GetById<FoodItem>(foodItemId);

            if (foodItem == null)
                throw new FoodItemNotFoundException("Food Item with given id doesnt exist", null, _logger);

            foodItem.SentimentScore = (decimal)score;
            foodItem.Description = feedback;
            await _foodItemService.Update(foodItem.Id, foodItem);
        }

        private static List<string> ExtractMajorSentiments(List<string> reviews, List<SentimentPrediction> predictions)
        {
            var keywordCounts = new Dictionary<string, int>();

            for (int i = 0; i < reviews.Count; i++)
            {
                var review = reviews[i];
                var prediction = predictions[i];

                if (prediction.PredictedLabel && prediction.Probability >= 0.65)
                {
                    UpdateKeywordCounts(review, AppConstants.PositiveKeywords, keywordCounts);
                }
                else if (!prediction.PredictedLabel && prediction.Probability >= 0.65)
                {
                    UpdateKeywordCounts(review, AppConstants.NegativeKeywords, keywordCounts);
                }
            }
            return keywordCounts
           .OrderByDescending(kv => kv.Value)
            .ThenBy(kv => AppConstants.PositiveKeywords.IndexOf(kv.Key))
            .ThenBy(kv => AppConstants.NegativeKeywords.IndexOf(kv.Key))
           .Select(kv => kv.Key)
           .ToList();
        }

        private static void UpdateKeywordCounts(string review, List<string> keywords, Dictionary<string, int> keywordCounts)
        {
            foreach (var keyword in keywords)
            {
                if (review.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    if (!keywordCounts.ContainsKey(keyword))
                    {
                        keywordCounts[keyword] = 0;
                    }
                    keywordCounts[keyword]++;
                }
            }
        }
    }
}
