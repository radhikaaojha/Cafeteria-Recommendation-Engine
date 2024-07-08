using CMS.Common.Enums;
using CMS.Common.Models;
using System.Text.Json;

namespace Client.Services
{
    public static class AdminService
    {
        public static async Task<CustomProtocol> ShowMenuForAdmin(int userId)
        {
            while (true)
            {
                CustomProtocol protocolRequest = new CustomProtocol();
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Select an option from the following:\n" +
                             "1. Add a new food item\n" +
                             "2. Remove food item\n" +
                             "3. Browse Menu of Cafeteria\n" +
                             "4. Update the price of a food item\n" +
                             "5. Update the availability status of a food item\n" +
                             "6. Generate discarded menu item list\n" +
                             "7. Roll out feedback questions for discarded item\n" +
                             "8. Remove discarded menu item\n" +
                             "9. Logout\n" +
                             "Enter the number corresponding to your choice ");
                Console.WriteLine(new string('-', 40));
                var userChoice = Console.ReadLine();
                protocolRequest.UserId = userId.ToString();
                switch (userChoice)
                {
                    case "1":
                        protocolRequest.Action = Actions.AddFoodItem.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForAddMenuItem());
                        break;
                    case "2":
                        protocolRequest.Action = Actions.RemoveFoodItem.ToString();
                        protocolRequest.Payload = GetInputForRemoveFoodItem();
                        break;
                    case "3":
                        protocolRequest.Action = Actions.BrowseMenu.ToString();
                        break;
                    case "4":
                        protocolRequest.Action = Actions.UpdateFoodItemPrice.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForUpdateFoodItemPrice());
                        break;
                    case "5":
                        protocolRequest.Action = Actions.UpdateFoodItemStatus.ToString();
                        protocolRequest.Payload = JsonSerializer.Serialize(GetInputForUpdateFoodItemStatus());
                        break;
                    case "6":
                        protocolRequest.Action = Actions.ViewDiscardList.ToString();
                        break;
                    case "7":
                        protocolRequest.Action = Actions.RollOutDetailedFeedbackQuestions.ToString();
                        break;
                    case "8":
                        protocolRequest.Action = Actions.RemoveDiscardedFoodItem.ToString();
                        protocolRequest.Payload = GetInputForRemoveFoodItem();
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

        private static object GetInputForUpdateFoodItemStatus()
        {
            FoodItemStatusUpdate foodItem = new();
            Console.WriteLine("Enter id of food item you wish to update status of");
            foodItem.FoodItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter status id");
            foodItem.StatusId = int.Parse(Console.ReadLine());
            return foodItem;
        }

        private static object GetInputForUpdateFoodItemPrice()
        {
            FoodItemPriceUpdate foodItem = new();
            Console.WriteLine("Enter id of food item you wish to update price of");
            foodItem.FoodItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price");
            foodItem.Price = decimal.Parse(Console.ReadLine());
            return foodItem;
        }

        private static string GetInputForRemoveFoodItem()
        {
            Console.WriteLine("Enter id of food item you wish to remove");
            return Console.ReadLine();
        }

        private static AddFoodItem GetInputForAddMenuItem()
        {
            AddFoodItem foodItem = new AddFoodItem();
            Console.Write("Enter item name: ");
            foodItem.Name = Console.ReadLine();

            Console.Write("Enter item type Id: ");
            foodItem.FoodItemTypeId = short.Parse(Console.ReadLine());
            Console.Write("Enter item price: ");
            foodItem.Price = short.Parse(Console.ReadLine());

            return foodItem;

        }
    }
}
