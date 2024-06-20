using CMS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public static class AdminService
    {
        public static async Task<CustomProtocolDTO> ShowMenuForAdmin(StreamWriter writer, StreamReader reader)
        {
            CustomProtocolDTO request = new CustomProtocolDTO();
            Console.WriteLine("\nSelect an option from the following:\n" +
                         "1. Add a new food item\n" +
                         "2. Remove food item\n" +
                         "3. View the daily menu\n" +
                         "4. Update the price of a food item\n" +
                         "5. Update the availability status of a food item\n" +
                         "6. Browse Menu of Cafeteria\n" +
                         "7. Logout\n" +
                         "Enter the number corresponding to your choice ");
            var requestString = Console.ReadLine();

            switch (requestString)
            {
                case "1":
                    request.Action = "AddFoodItem";
                    request.Payload = JsonSerializer.Serialize(GetInputForAddMenuItem());
                    break;
                case "2":
                    request.Action = "RemoveFoodItem";
                    request.Payload = JsonSerializer.Serialize(GetInputForRemoveFoodItem());
                    break;
                default:
                    Console.WriteLine("No such option");
                    break;

            }
            return request;
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
