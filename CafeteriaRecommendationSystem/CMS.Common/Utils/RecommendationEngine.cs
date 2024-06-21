using Azure;
using Azure.AI.TextAnalytics;
using CMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.Common.Utils
{
    public static class RecommendationEngine
    {
        public static string GetSentiments(string sentiments)
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
        }

        /*
        private static readonly HashSet<string> PositiveWords = new HashSet<string>
    {
        "delicious", "tasty", "yum", "amazing", "excellent", "great", "good", "wonderful"
    };

        private static readonly HashSet<string> NegativeWords = new HashSet<string>
    {
        "bad", "terrible", "disgusting", "awful", "horrible", "poor"
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

        public static (int score, int wordCount, List<string> foodKeywords) AnalyzeSentiment(List<string> words)
        {
            int score = 0;
            int wordCount = 0;
            bool negate = false;
            var foodKeywords = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                string twoWordPhrase = i < words.Count - 1 ? $"{word} {words[i + 1]}" : "";

                if (SentimentPhrases.TryGetValue(twoWordPhrase, out int phraseScore))
                {
                    score += phraseScore;
                    wordCount++;
                    foodKeywords.Add(twoWordPhrase);
                    i++;
                    negate = false;
                }
                else if (word == "not")
                {
                    negate = true;
                }
                else if (PositiveWords.Contains(word) || NegativeWords.Contains(word))
                {
                    int wordScore = PositiveWords.Contains(word) ? 1 : -1;
                    score += negate ? -wordScore : wordScore;
                    wordCount++;

                    string keyword = negate ? $"not {word}" : word;
                    foodKeywords.Add(keyword);

                    negate = false;
                }
                else
                {
                    negate = false; 
                }
            }

            return (score, wordCount, foodKeywords);
        }

        private static readonly Regex WordSplitRegex = new Regex(@"\w+", RegexOptions.Compiled);

        private static List<string> PreprocessText(string text)
        {
            return WordSplitRegex.Matches(text.ToLowerInvariant())
                .Cast<Match>()
                .Select(m => m.Value)
                .Where(word => !StopWords.Contains(word))
                .ToList();
        }

        public static SentimentAnalysisResult AnalyzeFeedback(string feedbackText)
        {
            var words = PreprocessText(feedbackText);
            var (sentimentScore, wordCount, foodKeywords) = AnalyzeSentiment(words);
            var otherKeyPhrases = ExtractKeyPhrases(words);

            return new SentimentAnalysisResult
            {
                SentimentScore = wordCount > 0 ? (double)sentimentScore / wordCount : 0,
                FoodKeywords = foodKeywords,
                OtherKeyPhrases = otherKeyPhrases
            };
        }

        private static List<string> ExtractKeyPhrases(List<string> words)
        {
            return words.Where(word => !RestaurantKeywords.Contains(word))
                        .Distinct()
                        .ToList();
        }
        */
    }
}
