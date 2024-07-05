using CMS.Common.Enums;
using CMS.Common.Models;
using System.Text.Json;

namespace Client
{
    public static class AdminService
    {
        public static async Task<CustomProtocolDTO> ShowMenuForAdmin(StreamWriter writer, StreamReader reader, int userId)
        {
            while (true)
            {
                CustomProtocolDTO request = new CustomProtocolDTO();
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
                var requestString = Console.ReadLine();
                request.UserId = userId.ToString();
                switch (requestString)
                {
                    case "1":
                        request.Action = Actions.AddFoodItem.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForAddMenuItem());
                        break;
                    case "2":
                        request.Action = Actions.RemoveFoodItem.ToString();
                        request.Payload = GetInputForRemoveFoodItem();
                        break;
                    case "3":
                        request.Action = Actions.BrowseMenu.ToString();
                        break;
                    case "4":
                        request.Action = Actions.UpdateFoodItemPrice.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForUpdateFoodItemPrice());
                        break;
                    case "5":
                        request.Action = Actions.UpdateFoodItemStatus.ToString();
                        request.Payload = JsonSerializer.Serialize(GetInputForUpdateFoodItemStatus());
                        break;
                    case "6":
                        request.Action = Actions.ViewDiscardList.ToString();
                        break;
                    case "7":
                        request.Action = Actions.RollOutDetailedFeedbackQuestions.ToString();
                        break;
                    case "8":
                        request.Action = Actions.RemoveDiscardedFoodItem.ToString();
                        request.Payload = GetInputForRemoveFoodItem();
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

        private static object GetInputForUpdateFoodItemStatus()
        {
            FoodItemStatusUpdate foodItemStatusUpdate = new();
            Console.WriteLine("Enter id of food item you wish to update status of");
            foodItemStatusUpdate.FoodItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter status id");
            foodItemStatusUpdate.StatusId = int.Parse(Console.ReadLine());
            return foodItemStatusUpdate;
        }

        private static object GetInputForUpdateFoodItemPrice()
        {
            FoodItemPriceUpdate foodItemPriceUpdate = new();
            Console.WriteLine("Enter id of food item you wish to update price of");
            foodItemPriceUpdate.FoodItemId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter price");
            foodItemPriceUpdate.Price = decimal.Parse(Console.ReadLine());
            return foodItemPriceUpdate;
        }

        private static string GetInputForRemoveFoodItem()
        {
            Console.WriteLine("Enter id of food item you wish to remove");
            return Console.ReadLine();
        }

        private static AddFoodItem GetInputForAddMenuItem()
        {
            AddFoodItem addFoodItem = new AddFoodItem();
            Console.Write("Enter item name: ");
            addFoodItem.Name = Console.ReadLine();

            Console.Write("Enter item type Id: ");
            addFoodItem.FoodItemTypeId = Int16.Parse(Console.ReadLine());
            Console.Write("Enter item price: ");
            addFoodItem.Price = Int16.Parse(Console.ReadLine());

            return addFoodItem;

        }
    }
}
