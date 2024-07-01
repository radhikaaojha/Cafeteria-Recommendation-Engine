using CMS.Common.Enums;
using CMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public class ChefService
    { 

        public static async Task<CustomProtocolDTO> ShowMenuForChef(StreamWriter writer, StreamReader reader, int userId)
        {
            while (true)
            {
                CustomProtocolDTO request = new CustomProtocolDTO();
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Select an option from the following:\n" +
                             "1. View top recommendations\n" +
                             "2. View Notifications\n" +
                             "3. Browse Menu of Cafeteria\n" +
                             "4. Plan next day menu\n" +
                             "5. Finalize Menu Selection\n" +
                             "6. View recommendation from employees\n" +
                             "7. View discarded menu item list\n" +
                             "8. Remove discarded menu item\n" +
                             "9. Roll out detailed feedback questions for discarded item\n" +
                             "10. Logout\n" +
                             "Enter the number corresponding to your choice ");
                Console.WriteLine(new string('-', 40)); 
                var requestString = Console.ReadLine();

                switch (requestString)
                {
                    case "1":
                        request.Action = Actions.TopRecommendations.ToString();
                        break;
                    case "2":
                        request.Action = Actions.ViewNotifications.ToString();
                        request.Payload = userId.ToString();
                        break;
                    case "3":
                        request.Action = Actions.BrowseMenu.ToString();
                        break;
                    case "4":
                        request.Action = Actions.PlanNextDayMenu.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForDailyMenu());
                        break;
                    case "5":
                        request.Action = Actions.FinalizeMenu.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForFinalMenu());
                        break;
                    case "6":
                        request.Action = Actions.ViewVotes.ToString();
                        break;
                    case "7":
                        request.Action = Actions.ViewDiscardList.ToString();
                        break;
                    case "8":
                        request.Action = Actions.RemoveDiscardedFoodItem.ToString();
                        request.Payload = GetInputForRemoveFoodItem();
                        break;
                    case "9":
                        request.Action = Actions.RollOutDetailedFeedbackQuestions.ToString();
                        break;
                    case "10":
                        request.Action = Actions.Logout.ToString();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        break;

                }
                return request;
            }
        }

        private static string GetInputForRemoveFoodItem()
        {
            Console.WriteLine("Enter id of food item you wish to remove");
            return Console.ReadLine();
        }

        private static object GetInputForDailyMenu()
        {
            DailyMenuInput dailyMenuInput = new();
            dailyMenuInput.Breakfast = GetFoodItemIds("breakfast",3, dailyMenuInput);
            dailyMenuInput.Lunch = GetFoodItemIds("lunch", 3, dailyMenuInput);
            dailyMenuInput.Dinner = GetFoodItemIds("dinner", 3, dailyMenuInput);
            return dailyMenuInput;
        }
        static List<string> GetFoodItemIds(string mealType, int count, DailyMenuInput menuInput)
        {
            while (true)
            {
                Console.WriteLine($"Enter Ids for {count} food items you plan to make for {mealType} separated by ','");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Please enter food item ID.");
                    continue;
                }

                var ids = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(id => id.Trim()).Distinct().ToList();
                if (ids.Any(id => !int.TryParse(id, out _)))
                {
                    Console.WriteLine("Invalid input. Food item IDs must be numeric.");
                    continue;
                }

                if (ids.Count != ids.Distinct().Count())
                {
                    Console.WriteLine($"Invalid input. Please enter distinct IDs for {mealType}.");
                    continue;
                }

                var allIds = new HashSet<string>(menuInput.Breakfast.Concat(menuInput.Lunch).Concat(menuInput.Dinner));
                if (allIds.Intersect(ids).Any())
                {
                    Console.WriteLine($"Invalid input. IDs for {mealType} should be distinct from other meal types.");
                    continue;
                }

                if (ids.Count == count )
                {
                    return ids;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter exactly {count} and distinct food item IDs separated by commas.");
                }
            }
        }
        private static object GetInputForFinalMenu()
        {
            DailyMenuInput dailyMenuInput = new();
            dailyMenuInput.Breakfast = GetFoodItemIds("breakfast",2, dailyMenuInput);
            dailyMenuInput.Lunch = GetFoodItemIds("lunch", 2, dailyMenuInput);
            dailyMenuInput.Dinner = GetFoodItemIds("dinner", 2, dailyMenuInput);
            return dailyMenuInput;
        }
    }
}
