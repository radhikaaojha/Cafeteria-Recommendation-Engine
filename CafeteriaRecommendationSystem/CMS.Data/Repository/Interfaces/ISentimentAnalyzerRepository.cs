using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository.Interfaces
{
    public interface ISentimentAnalyzerRepository
    {
        Task<List<FoodItem>> GetNextDayMenuRecommendation();
    }
}
