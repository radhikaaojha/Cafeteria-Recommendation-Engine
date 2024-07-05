using CMS.Common.Enums;
using CMS.Common.Models;
using System.Text.Json;

namespace Client
{
    public class ChefService
    {

        public static async Task<CustomProtocolDTO> ShowMenuForChef(int userId)
        {
            while (true)
            {
                CustomProtocolDTO protocolRequest = new CustomProtocolDTO();
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Select an option from the following:\n" +
                             "1. View top recommendations\n" +
                             "2. View Notifications\n" +
                             "3. Browse Menu of Cafeteria\n" +
                             "4. Plan next day menu\n" +
                             "5. Finalize Menu Selection\n" +
                             "6. View recommendation from employees\n" +
                             "7. Generate discarded menu item list\n" +
                             "8. Remove discarded menu item\n" +
                             "9. Roll out detailed feedback questions for discarded item\n" +
                             "10. Logout\n" +
                             "Enter the number corresponding to your choice ");
                Console.WriteLine(new string('-', 40));
                var userChoice = Console.ReadLine();
                protocolRequest.UserId = userId.ToString();
                switch (userChoice)
                {
                    case "1":
                        protocolRequest.Action = Actions.TopRecommendations.ToString();
                        break;
                    case "2":
                        protocolRequest.Action = Actions.ViewNotifications.ToString();
                        protocolRequest.Payload = userId.ToString();
                        break;
                    case "3":
                        protocolRequest.Action = Actions.BrowseMenu.ToString();
                        break;
                    case "4":
                        protocolRequest.Action = Actions.PlanNextDayMenu.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForDailyMenu());
                        break;
                    case "5":
                        protocolRequest.Action = Actions.FinalizeMenu.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForFinalMenu());
                        break;
                    case "6":
                        protocolRequest.Action = Actions.ViewVotes.ToString();
                        break;
                    case "7":
                        protocolRequest.Action = Actions.ViewDiscardList.ToString();
                        break;
                    case "8":
                        protocolRequest.Action = Actions.RemoveDiscardedFoodItem.ToString();
                        protocolRequest.Payload = GetInputForRemoveFoodItem();
                        break;
                    case "9":
                        protocolRequest.Action = Actions.RollOutDetailedFeedbackQuestions.ToString();
                        break;
                    case "10":
                        protocolRequest.Action = Actions.Logout.ToString();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        continue;

                }
                return protocolRequest;
            }
        }

        private static string GetInputForRemoveFoodItem()
        {
            Console.WriteLine("Enter id of food item you wish to remove");
            return Console.ReadLine();
        }

        private static object GetInputForDailyMenu()
        {
            MenuInput dailyMenu = new();
            dailyMenu.Breakfast = GetFoodItemIds("breakfast", 3, dailyMenu);
            dailyMenu.Lunch = GetFoodItemIds("lunch", 3, dailyMenu);
            dailyMenu.Dinner = GetFoodItemIds("dinner", 3, dailyMenu);
            return dailyMenu;
        }
        static List<string> GetFoodItemIds(string mealType, int count, MenuInput menuInput)
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

                if (ids.Count == count)
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
            MenuInput finalMenu = new();
            finalMenu.Breakfast = GetFoodItemIds("breakfast", 2, finalMenu);
            finalMenu.Lunch = GetFoodItemIds("lunch", 2, finalMenu);
            finalMenu.Dinner = GetFoodItemIds("dinner", 2, finalMenu);
            return finalMenu;
        }
    }
}
