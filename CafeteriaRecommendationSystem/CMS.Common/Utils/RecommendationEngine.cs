using Azure;
using Azure.AI.TextAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Utils
{
    public static class RecommendationEngine
    {
        public static string GetSentiments(string sentiments)
        {
            List<string> feedbacks = new();
            //var client = new TextAnalyticsClient(new Uri("https://jaipur.cognitiveservices.azure.com/"), new AzureKeyCredential("5f9cec408ad34716ac37a45177dba143"));
            var client = new TextAnalyticsClient(new Uri("ur;"), new AzureKeyCredential("key"));
            var response = client.ExtractKeyPhrases(sentiments);
            KeyPhraseCollection keyPhrases = response.Value;

            foreach (string keyphrase in keyPhrases)
            {
                feedbacks.Add(keyphrase);
            }
            return string.Join(", ", feedbacks);
        }
        public static double AnalyzeSentimentScore(string text)
        {
            var client = new TextAnalyticsClient(new Uri("ur;"), new AzureKeyCredential("key"));
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(text);
            return documentSentiment.ConfidenceScores.Positive;
        }
    }
}
