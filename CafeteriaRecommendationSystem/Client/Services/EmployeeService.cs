using CMS.Common.Enums;
using CMS.Common.Models;
using System.Text.Json;

namespace Client.Services
{
    public static class EmployeeService
    {
        public static async Task<CustomProtocol> ShowMenuForEmployee(int userId)
        {
            while (true)
            {
                CustomProtocol protocolRequest = new CustomProtocol();
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
                var userChoice = Console.ReadLine();
                protocolRequest.UserId = userId.ToString();
                switch (userChoice)
                {
                    case "1":
                        protocolRequest.Action = Actions.VoteForMenu.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForVoting(userId));
                        break;
                    case "2":
                        protocolRequest.Action = Actions.ViewNotifications.ToString();
                        protocolRequest.Payload = userId.ToString();
                        break;
                    case "3":
                        protocolRequest.Action = Actions.BrowseMenu.ToString();
                        break;
                    case "4":
                        protocolRequest.Action = Actions.SubmitFeedback.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForFeedback(userId));
                        break;
                    case "5":
                        protocolRequest.Action = Actions.ViewRolledOutItems.ToString();
                        protocolRequest.Payload = userId.ToString();
                        break;
                    case "6":
                        protocolRequest.Action = Actions.ViewTodaysMenu.ToString();
                        protocolRequest.Payload = userId.ToString();
                        break;
                    case "7":
                        protocolRequest.Action = Actions.SubmitDetailedFeedback.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForDetailedFeedback(userId));
                        break;
                    case "8":
                        protocolRequest.Action = Actions.UserPreference.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForUserPreferences(userId));
                        break;
                    case "9":
                        protocolRequest.Action = Actions.Logout.ToString();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        continue;

                }
                return protocolRequest;
            }
        }

        public static List<UserPreferences> GetInputForUserPreferences(int userId)
        {
            var preferences = new List<UserPreferences>();
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

                preferences.Add(new UserPreferences
                {
                    UserId = userId,
                    CharacteristicId = characteristicId,
                    Priority = priority
                });
            }

            return preferences;
        }

        public static DetailedFeedback GetInputForDetailedFeedback(int userId)
        {
            DetailedFeedback detailedFeedback = new();
            Console.WriteLine("Enter id of food item you wish to give feedback for");
            detailedFeedback.FoodItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Note : Please press enter if you wish to leave it empty");
            Console.WriteLine($"Q1. What didn’t you like about {detailedFeedback.FoodItemId}?");
            string answer1 = Console.ReadLine();

            Console.WriteLine($"Q2. How would you like {detailedFeedback.FoodItemId} to taste?");
            string answer2 = Console.ReadLine();

            Console.WriteLine($"Q3. Share your moms recipe");
            string answer3 = Console.ReadLine();

            var feedback = new DetailedFeedback
            {
                UserId = userId,
                FoodItemId = detailedFeedback.FoodItemId,
                Answer1 = answer1,
                Answer2 = answer2,
                Answer3 = answer3
            };

            return feedback;
        }

        private static object GetInputForVoting(int userId)
        {
            UserMealPreference userMealPreference = new();
            userMealPreference.Breakfast = GetFoodItemId("breakfast");
            userMealPreference.Lunch = GetFoodItemId("lunch");
            userMealPreference.Dinner = GetFoodItemId("dinner");
            userMealPreference.UserId = userId;
            return userMealPreference;
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
            bool isValidRating = false;
            Feedback feedback = new Feedback();
            feedback.UserId = userId;
            Console.WriteLine("Enter id of food item you wish to give feedback for");
            feedback.FoodItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter feedback");
            feedback.Comment = Console.ReadLine();
            int rating;
            do
            {
                Console.WriteLine("Enter rating between 0 to 5");
                string input = Console.ReadLine();
                if (int.TryParse(input, out rating))
                {
                    if (rating >= 0 && rating <= 5)
                    {
                        isValidRating = true;
                    }
                    else
                    {
                        Console.WriteLine("Rating must be between 0 and 5.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            } while (!isValidRating);
            feedback.Rating = rating;
            return feedback;
        }
    }
}
