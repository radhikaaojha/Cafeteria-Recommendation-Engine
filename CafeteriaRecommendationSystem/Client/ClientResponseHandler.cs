using CMS.Common.Models;
using System.Text.Json;

namespace Client
{
    public static class ClientResponseHandler
    {
        public static void BrowseMenu(string response)
        {
            List<ViewFoodItem> menus = JsonSerializer.Deserialize<List<ViewFoodItem>>(response);
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("|  ID  |        Name        |   Price   |        Description        | Sentiment | Availability | ItemType |");
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            foreach (var menu in menus)
            {
                Console.WriteLine($"| {menu.Id,4} | {menu.Name,-18} | {menu.Price,9:C2} | {menu.Description,-25} | {menu.SentimentScore,9} | {menu.AvailabilityStatus,-12} | {menu.FoodItemType,-8} |");
            }

            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }

        public static void ShowTopRecommendations(string response)
        {
            List<RecommendedItem> recommendedItems = JsonSerializer.Deserialize<List<RecommendedItem>>(response);
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("|  ID  |        Name        |        Description        | Sentiment Score |");
            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (var item in recommendedItems)
            {
                Console.WriteLine($"| {item.Id,4} | {item.Name,-18} | {item.Description,-25} | {item.SentimentScore,15} |");
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

        }

        public static void ShowNotifications(string response)
        {
            List<ViewNotification> notifications = JsonSerializer.Deserialize<List<ViewNotification>>(response);

            if(notifications.Count == 0)
                Console.WriteLine("No unread notifications!"); 

            foreach (var notification in notifications)
            {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine(notification.Message);
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }
        
        public static void ShowVotesForFoodItem(string response)
        {
            List<FoodItemVotingStats> foodItems = JsonSerializer.Deserialize<List<FoodItemVotingStats>>(response);

            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("|  ID  |        Name        |  Number of Votes  |      Meal Type      |");
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            foreach (var item in foodItems)
            {
                Console.WriteLine("| {0,-4} | {1,-18} | {2,-18} | {3,-18} |", item.FoodItemId, Truncate(item.Name, 18), item.NumberOfVotes, Truncate(item.MealType, 18));
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

        }

        public static void ShowDailyMenu(string response)
        {
            var rolledOutFoodItems = JsonSerializer.Deserialize<BrowseNextDayMenu>(response);

            Console.WriteLine("--------------------------------------------------------------------------------");
            
            Console.WriteLine("Breakfast:");
            DisplayMeal(rolledOutFoodItems.Breakfast);

            Console.WriteLine("\nLunch:");
            DisplayMeal(rolledOutFoodItems.Lunch);

            Console.WriteLine("\nDinner:");
            DisplayMeal(rolledOutFoodItems.Dinner);

            Console.WriteLine("--------------------------------------------------------------------------------");

        }

        public static void ShowDiscardFoodItemList(string response)
        {
            var discardedFoodItem = JsonSerializer.Deserialize<ViewFoodItem>(response);

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("|  ID  |        Name        |   Price   |        Description        | Sentiment | Availability | ItemType |");
            Console.WriteLine("--------------------------------------------------------------------------------------------");

            Console.WriteLine($"| {discardedFoodItem.Id,4} | {discardedFoodItem.Name,-18} | {discardedFoodItem.Price,9:C2} | {discardedFoodItem.Description,-25} | {discardedFoodItem.SentimentScore,9} | {discardedFoodItem.AvailabilityStatus,-12} | {discardedFoodItem.FoodItemType,-8} |");

            Console.WriteLine("--------------------------------------------------------------------------------");

        }

        private static void DisplayMeal(List<RecommendedItem> mealItems)
        {
            if (mealItems.Count == 0)
            {
                Console.WriteLine("No items available.");
                return;
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("|  ID  |        Name        |        Description        | Sentiment Score |");
            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (var item in mealItems)
            {
                Console.WriteLine("| {0,-4} | {1,-18} | {2,-24} | {3,-15:N2} |", item.Id, Truncate(item.Name, 18), Truncate(item.Description, 24), item.SentimentScore);
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        private static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
        }
    }
}
