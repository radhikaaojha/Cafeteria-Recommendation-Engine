using CMS.Common.Models;
using System.Text.RegularExpressions;

namespace CMS.Common.Utils
{
    public static class RecommendationEngine
    {
        /*public static string GetSentiments(string sentiments)
        {
            List<string> feedbacks = new();
            // var client = new TextAnalyticsClient(new Uri("https://crs-sentimentanalyser.cognitiveservices.azure.com/"), new AzureKeyCredential("89067196840f401e959f5aab2f1f1081"));
            var client = new TextAnalyticsClient(new Uri("https://jaipur.cognitiveservices.azure.com/"), new AzureKeyCredential("5f9cec408ad34716ac37a45177dba143"));

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
        }*/


        private static readonly HashSet<string> PositiveWords = new HashSet<string>
    {
        "delicious", "tasty", "yum", "amazing", "excellent", "great", "good", "wonderful", "fresh"
    };

        private static readonly HashSet<string> NegativeWords = new HashSet<string>
    {
        "bad", "terrible", "disgusting", "awful", "horrible", "poor","dull"
    };

        private static readonly HashSet<string> StopWords = new HashSet<string>
    {
        "the", "was", "and", "is", "in", "of", "to", "for", "with", "not"
    };

        private static readonly HashSet<string> RestaurantKeywords = new HashSet<string>
    {
        "restaurant", "service", "waiter", "waitress", "ambiance", "environment", "place", "location"
    };

        private static readonly Dictionary<string, int> SentimentPhrases = new Dictionary<string, int>
        {
            // Negative phrases
            {"not tasty", -1},
            {"not good", -1},
            {"not great", -1},
            {"not fresh", -1},
            {"not worth", -1},
            {"not recommended", -1},
            {"not impressed", -1},
            {"not satisfactory", -1},
            {"very disappointing", -2},
            {"extremely disappointing", -2},
            {"highly disappointing", -2},
            {"too expensive", -1},
            {"overpriced for", -1},
    
            // Positive phrases
            {"not bad", 1},
            {"very good", 2},
            {"very tasty", 2},
            {"really good", 2},
            {"really tasty", 2},
            {"pretty good", 1},
            {"quite good", 1},
            {"highly recommend", 2},
            {"strongly recommend", 2},
            {"absolutely delicious", 2},
            {"very delicious", 2},
            {"extremely delicious", 2},
            {"great value", 2},
            {"good value", 1},
    
            // Neutral or context-dependent phrases
            {"could be better", 0},
            {"room for improvement", 0},
    
            // Intensifiers
            {"very bad", -2},
            {"really bad", -2},
            {"extremely bad", -2},
            {"very terrible", -2},
            {"really terrible", -2},
            {"very excellent", 2},
            {"really excellent", 2},
            {"extremely excellent", 2}
        };

        public static (double averageScore, string keyPhrases) AnalyzeSentiment(List<string> feedbacks)
        {
            if (feedbacks == null || feedbacks.Count == 0)
            {
                return (0, "");
            }

            double totalScore = 0;
            var allKeyPhrases = new HashSet<string>();

            foreach (var feedback in feedbacks)
            {
                var words = feedback.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                double feedbackScore = 0;

                foreach (var word in words)
                {
                    string lowerWord = word.ToLower();
                    if (PositiveWords.Contains(lowerWord))
                    {
                        feedbackScore += 1;
                        allKeyPhrases.Add(lowerWord);
                    }
                    else if (NegativeWords.Contains(lowerWord))
                    {
                        feedbackScore -= 1;
                        allKeyPhrases.Add(lowerWord);
                    }
                    else if (IsKeyPhrase(lowerWord))
                    {
                        allKeyPhrases.Add(lowerWord);
                    }
                }

                totalScore += words.Length > 0 ? feedbackScore / words.Length : 0;
            }

            double averageScore = feedbacks.Count > 0 ? totalScore / feedbacks.Count : 0;
            string keyPhrasesString = string.Join(", ", allKeyPhrases);

            return (averageScore, keyPhrasesString);
        }

        private static bool IsKeyPhrase(string word)
        {
            var keyPhrases = new HashSet<string> { "yum", "fresh", "delicious", "tasty", "service", "ambiance", "price" };
            return keyPhrases.Contains(word);
        }

    }
}
