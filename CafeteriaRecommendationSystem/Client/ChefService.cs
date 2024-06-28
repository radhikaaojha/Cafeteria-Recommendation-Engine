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
                             "7. Logout\n" +
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
                        request.Action = Actions.Logout.ToString();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        break;

                }
                return request;
            }
        }

        private static object GetInputForDailyMenu()
        {
            DailyMenuInput dailyMenuInput = new();
            dailyMenuInput.Breakfast = GetFoodItemIds("breakfast",3);
            dailyMenuInput.Lunch = GetFoodItemIds("lunch", 3);
            dailyMenuInput.Dinner = GetFoodItemIds("dinner", 3);
            return dailyMenuInput;
        }
        static List<string> GetFoodItemIds(string mealType, int count)
        {
            while (true)
            {
                Console.WriteLine($"Enter Ids for 3 food items you plan to make for {mealType} separated by ','");
                var input = Console.ReadLine();
                var ids = input.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(id => id.Trim()).ToList();

                if (ids.Count == count)
                {
                    return ids;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter exactly {count} food item IDs separated by commas.");
                }
            }
        }
        private static object GetInputForFinalMenu()
        {
            DailyMenuInput dailyMenuInput = new();
            dailyMenuInput.Breakfast = GetFoodItemIds("breakfast",2);
            dailyMenuInput.Lunch = GetFoodItemIds("lunch", 2);
            dailyMenuInput.Dinner = GetFoodItemIds("dinner", 2);
            return dailyMenuInput;
        }
    }
}
