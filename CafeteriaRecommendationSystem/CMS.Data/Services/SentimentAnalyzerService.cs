using CMS.Data.Repository.Interfaces;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services
{
    public class SentimentAnalyzerService : ISentimentAnalyzerService
    {
        private ISentimentAnalyzerRepository _sentimentAnalyzerRepository;
        public SentimentAnalyzerService(ISentimentAnalyzerRepository sentimentAnalyzerRepository) 
        { 
            _sentimentAnalyzerRepository = sentimentAnalyzerRepository;
        }
        public async Task<List<FoodItem>> GetTopRecommendationForChef()
        {
            return await _sentimentAnalyzerRepository.GetNextDayMenuRecommendation();
        }
    }
}
