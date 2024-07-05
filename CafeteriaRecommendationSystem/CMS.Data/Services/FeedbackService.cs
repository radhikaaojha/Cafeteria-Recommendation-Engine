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

        public async Task<(float, string)> AnalyzeFeedbackSentiments(int foodItemId)
        {
            Expression<Func<FoodItemFeedback, bool>> predicate = data => data.FoodItemId == foodItemId;

            var feedbacksList = await base.GetList<FoodItemFeedback>(null, null, null, 0, 0, predicate);

            var foodReviews = _mapper.Map<List<FoodReview>>(feedbacksList);

            var context = new MLContext();
            string dataPath = AppConstants.DataPathForTrainedModel;
            var data = context.Data.LoadFromTextFile<FoodReview>(dataPath, separatorChar: ',', hasHeader: true);
            var pipeline = context.Transforms.Text.FeaturizeText("Features", nameof(FoodReview.ReviewText)).Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Sentiment", featureColumnName: "Features"));
            var model = pipeline.Fit(data);
            var predictor = context.Model.CreatePredictionEngine<FoodReview, SentimentPrediction>(model);

            var sentiments = foodReviews.Select(review => new
            {
                Review = review,
                Prediction = predictor.Predict(review)
            }).ToList();

            var groupedByFoodItem = sentiments.First().Review.FoodItemId;
            var reviews = sentiments.Select(g => g.Review.ReviewText).ToList();

            var averageProbability = sentiments.Average(g => g.Prediction.Probability) * 100;

            var majorSentiments = ExtractMajorSentiments(reviews, sentiments.Select(g => g.Prediction).ToList());
            var sentiment = (string.Join(", ", majorSentiments));
            return (averageProbability, sentiment);

        }

        public async Task SubmitDetailedFeedback(Common.Models.DetailedFeedback detailedFeedbackRequest)
        {
            DetailedFoodItemFeedback detailedFoodItemFeedback = _mapper.Map<DetailedFoodItemFeedback>(detailedFeedbackRequest);
            await _feedbackRepository.SubmitDetailedFeedback(detailedFoodItemFeedback);
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
                    UpdateKeywordCounts(review,AppConstants.PositiveKeywords, keywordCounts);
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
