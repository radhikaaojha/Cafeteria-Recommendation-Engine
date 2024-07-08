using CMS.Common.Enums;
using CMS.Common.Models;
using System.Text.Json;

namespace Client.Services
{
    public class ChefService
    {

        public static async Task<CustomProtocol> ShowMenuForChef(int userId)
        {
            while (true)
            {
                CustomProtocol protocolRequest = new CustomProtocol();
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Select an option from the following:\n" +
                             "1. View top recommendations\n" +
                             "2. View Notifications\n" +
                             "3. View Menu of Cafeteria\n" +
                             "4. Plan next day menu\n" +
                             "5. Finalize Menu Selection\n" +
                             "6. View recommendation from employees\n" +
                             "7. Generate discarded menu item list\n" +
                             "8. Remove discarded menu item\n" +
                             "9. Roll out detailed feedback questions for discarded item\n" +
                             "10. Discard food item\n" +
                             "11. Logout\n" +
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
                        protocolRequest.Action = Actions.ViewMenu.ToString();
                        break;
                    case "4":
                        protocolRequest.Action = Actions.PlanNextDayMenu.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForPlannedMenu());
                        break;
                    case "5":
                        protocolRequest.Action = Actions.FinalizeMenu.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForFinalMenu());
                        break;
                    case "6":
                        protocolRequest.Action = Actions.ViewVotes.ToString();
                        break;
                    case "7":
                        protocolRequest.Action = Actions.GenerateDiscardList.ToString();
                        break;
                    case "8":
                        protocolRequest.Action = Actions.RemoveDiscardedFoodItem.ToString();
                        protocolRequest.Payload = GetInputForFoodItemId();
                        break;
                    case "9":
                        protocolRequest.Action = Actions.RollOutDetailedFeedbackQuestions.ToString();
                        break;
                    case "10":
                        protocolRequest.Action = Actions.DiscardFoodItem.ToString();
                        protocolRequest.Payload = GetInputForFoodItemId();
                        break;
                    case "11":
                        protocolRequest.Action = Actions.Logout.ToString();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        continue;

                }
                return protocolRequest;
            }
        }

        private static string GetInputForFoodItemId()
        {
            Console.WriteLine("Enter id of food item:");
            return Console.ReadLine();
        }

        private static object GetInputForPlannedMenu()
        {
            Menu plannedMenu = new();
            plannedMenu.Breakfast = GetFoodItemIds("breakfast", 3, plannedMenu);
            plannedMenu.Lunch = GetFoodItemIds("lunch", 3, plannedMenu);
            plannedMenu.Dinner = GetFoodItemIds("dinner", 3, plannedMenu);
            return plannedMenu;
        }

        private static object GetInputForFinalMenu()
        {
            Menu finalMenu = new();
            finalMenu.Breakfast = GetFoodItemIds("breakfast", 2, finalMenu);
            finalMenu.Lunch = GetFoodItemIds("lunch", 2, finalMenu);
            finalMenu.Dinner = GetFoodItemIds("dinner", 2, finalMenu);
            return finalMenu;
        }


        static List<string> GetFoodItemIds(string mealType, int numberOfAllowedIFoodItems, Menu menu)
        {
            while (true)
            {
                Console.WriteLine($"Enter Ids for {numberOfAllowedIFoodItems} food items you plan to make for {mealType} separated by ','");
                var foodItemsId = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(foodItemsId))
                {
                    Console.WriteLine("Invalid input. Please enter food item ID.");
                    continue;
                }

                var foodItemIds = foodItemsId.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(id => id.Trim()).Distinct().ToList();
                if (foodItemIds.Any(id => !int.TryParse(id, out _)))
                {
                    Console.WriteLine("Invalid input. Food item IDs must be numeric.");
                    continue;
                }

                if (foodItemIds.Count != foodItemIds.Distinct().Count())
                {
                    Console.WriteLine($"Invalid input. Please enter distinct IDs for {mealType}.");
                    continue;
                }

                var allFoodItemIds = new HashSet<string>(menu.Breakfast.Concat(menu.Lunch).Concat(menu.Dinner));
                if (allFoodItemIds.Intersect(foodItemIds).Any())
                {
                    Console.WriteLine($"Invalid input. IDs for {mealType} should be distinct from other meal types.");
                    continue;
                }

                if (foodItemIds.Count == numberOfAllowedIFoodItems)
                {
                    return foodItemIds;
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter exactly {numberOfAllowedIFoodItems} and distinct food item IDs separated by commas.");
                }
            }
        }

    }
}
