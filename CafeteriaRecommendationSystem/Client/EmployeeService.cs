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
                Console.WriteLine("\nSelect an option from the following:\n" +
                             "1. Vote for menu\n" +
                             "2. View Notifications\n" +
                             "3. Browse Menu of Cafeteria\n" +
                             "4. Submit feedback\n" +
                             "5. Logout\n" +
                             "Enter the number corresponding to your choice ");
                var requestString = Console.ReadLine();

                switch (requestString)
                {
                    case "1":
                        request.Action = Actions.VoteForMenu.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForVoting());
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
                        request.Action = Actions.Logout.ToString();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        continue;

                }
                return request;
            }
        }

        private static object GetInputForVoting()
        {
            DailyMenuInput votingMenuInput = new();
            Console.WriteLine("Enter Id for 2 food items you vote to make for breakfast separated by ','");
            var breakfast = Console.ReadLine();
            Console.WriteLine("Enter Id for 2 food items you vote to make for lunch separated by ','");
            var lunch = Console.ReadLine();
            Console.WriteLine("Enter Id for 2 food items you vote to make for dinner separated by ','");
            var dinner = Console.ReadLine();
            votingMenuInput.Breakfast = new List<string>(breakfast.Split(',', StringSplitOptions.RemoveEmptyEntries));
            votingMenuInput.Lunch = new List<string>(lunch.Split(',', StringSplitOptions.RemoveEmptyEntries));
            votingMenuInput.Dinner = new List<string>(dinner.Split(',', StringSplitOptions.RemoveEmptyEntries));
            return votingMenuInput;
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
    }
}
