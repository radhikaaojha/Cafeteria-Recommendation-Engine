using CMS.Common.Enums;
using CMS.Common.Models;
using System.Text.Json;

namespace Client
{
    public static class EmployeeService
    {
        public static async Task<CustomProtocolDTO> ShowMenuForEmployee(StreamWriter writer, StreamReader reader, int userId)
        {
            while (true)
            {
                CustomProtocolDTO request = new CustomProtocolDTO();
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Select an option from the following:\n" +
                             "1. Vote for menu\n" +
                             "2. View Notifications\n" +
                             "3. Browse Menu of Cafeteria\n" +
                             "4. Submit feedback\n" +
                             "5. View rolled out items for tommorrow menu\n" +
                             "6. View today's menu\n" +
                             "7. Submit detailed food item feedback\n" +
                             "8. Submit food preference\n" +
                             "9. Logout\n" +
                             "Enter the number corresponding to your choice ");
                Console.WriteLine(new string('-', 40));
                var requestString = Console.ReadLine();

                switch (requestString)
                {
                    case "1":
                        request.Action = Actions.VoteForMenu.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForVoting(userId));
                        break;
                    case "2":
                        request.Action = Actions.ViewNotifications.ToString();
                        request.Payload = userId.ToString();
                        break;
                    case "3":
                        request.Action = Actions.BrowseMenu.ToString();
                        break;
                    case "4":
                        request.Action = Actions.SubmitFeedback.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForFeedback(userId));
                        break;
                    case "5":
                        request.Action = Actions.ViewNextDayMenu.ToString();
                        request.Payload = userId.ToString();
                        break;
                    case "6":
                        request.Action = Actions.ViewTodaysMenu.ToString();
                        request.Payload = userId.ToString();
                        break;
                    case "7":
                        request.Action = Actions.SubmitDetailedFeedback.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForDetailedFeedback(userId));
                        break;
                    case "8":
                        request.Action = Actions.UserPreference.ToString();
                        request.Payload = JsonSerializer.Serialize(CollectUserPreferences(userId));
                        break;
                    case "9":
                        request.Action = Actions.Logout.ToString();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        continue;

                }
                return request;
            }
        }

        public static List<UserPreferenceInput> CollectUserPreferences(int userId)
        {
            var preferences = new List<UserPreferenceInput>();
            var characteristicIds = Enum.GetValues(typeof(FoodCharacterstic)).Cast<FoodCharacterstic>().ToList();

            foreach (var characteristicId in characteristicIds)
            {
                Console.WriteLine($"Enter priority for {characteristicId} (On a scale of 11): ");
                int priority;
                bool isValidPriority = false;

                do
                {
                    if (!int.TryParse(Console.ReadLine(), out priority))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        continue;
                    }

                    if (preferences.Any(p => p.Priority == priority))
                    {
                        Console.WriteLine($"Priority {priority} is already assigned to another characteristic. Please choose a different priority.");
                    }
                    else
                    {
                        isValidPriority = true;
                    }
                } while (!isValidPriority);

                preferences.Add(new UserPreferenceInput
                {
                    UserId = userId,
                    CharacteristicId = characteristicId,
                    Priority = priority
                });
            }

            return preferences;
        }

        public static DetailedFeedbackRequest GetInputForDetailedFeedback(int userId)
        {
            DetailedFeedbackRequest detailedFeedbackRequest = new();
            Console.WriteLine("Enter id of food item you wish to give feedback for");
            detailedFeedbackRequest.FoodItemId = int.Parse(Console.ReadLine());

            Console.WriteLine($"Q1. What didn’t you like about {detailedFeedbackRequest.FoodItemId}?");
            string answer1 = Console.ReadLine();

            Console.WriteLine($"Q2. How would you like {detailedFeedbackRequest.FoodItemId} to taste?");
            string answer2 = Console.ReadLine();

            Console.WriteLine($"Q3. Share your moms recipe");
            string answer3 = Console.ReadLine();

            var feedback = new DetailedFeedbackRequest
            {
                UserId = userId,
                FoodItemId = detailedFeedbackRequest.FoodItemId,
                Answer1 = answer1,
                Answer2 = answer2,
                Answer3 = answer3
            };

            return feedback;
        }

        private static object GetInputForVoting(int userId)
        {
            VotingMenuInput votingMenuInput = new();
            votingMenuInput.Breakfast = GetFoodItemId("breakfast");
            votingMenuInput.Lunch = GetFoodItemId("lunch");
            votingMenuInput.Dinner = GetFoodItemId("dinner");
            votingMenuInput.UserId = userId;
            return votingMenuInput;
        }
        static List<string> GetFoodItemId(string mealType)
        {
            while (true)
            {
                Console.WriteLine($"Enter the Id for a food item you vote to make for {mealType}:");
                var input = Console.ReadLine();
                var ids = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(id => id.Trim()).ToList();

                if (ids.Count == 1)
                {
                    return ids;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter exactly 1 food item ID.");
                }
            }
        }
        private static object GetInputForFeedback(int userId)
        {
            FeedbackRequest feedbackRequest = new FeedbackRequest();
            feedbackRequest.UserId = userId;
            Console.WriteLine("Enter id of food item you wish to give feedback for");
            feedbackRequest.FoodItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter feedback");
            feedbackRequest.Comment = (Console.ReadLine());
            Console.WriteLine("Enter rating between 0 to 5");
            feedbackRequest.Rating = int.Parse(Console.ReadLine());
            return feedbackRequest;
        }
        public static bool ValidatePriority(List<UserPreferenceInput> userPreferences, int newPriority)
        {
            return userPreferences.Any(up => up.Priority == newPriority);
        }
    }
}
