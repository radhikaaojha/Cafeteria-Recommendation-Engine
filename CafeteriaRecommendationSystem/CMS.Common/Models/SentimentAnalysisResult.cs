using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Models
{
    public class SentimentAnalysisResult
    {
        public double SentimentScore { get; set; }
        public string Sentiment { get; set; }
    }
}
