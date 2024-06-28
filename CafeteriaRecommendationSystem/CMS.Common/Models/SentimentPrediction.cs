using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class CafeReview
    {
        public string FoodItem { get; set; }
        public string Comment { get; set; }
        public float SentimentScore { get; set; }
        public bool IsPositive { get; set; }
    }
    public class FoodReview
    {
        [LoadColumn(0)]
        public int FoodItemId { get; set; }

        [LoadColumn(1)]
        public string ReviewText { get; set; }

        [LoadColumn(2)]
        public bool Sentiment { get; set; }

    }
    public class AnalyzedReview
    {
        public string FoodItem { get; set; }
        public string ReviewText { get; set; }
        public float SentimentScore { get; set; }
        public List<string> KeyPhrases { get; set; }
    }
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool PredictedLabel { get; set; }
        [ColumnName("Score")]
        public float Score { get; set; }
        [ColumnName("Probability")]
        public float Probability { get; set; }
    }

}
