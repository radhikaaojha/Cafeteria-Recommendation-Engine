using AutoMapper;
using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Common;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace CMS.Data.Services
{
    public class AdminService : IAdminService
    {
        private IFoodItemService _foodItemService;
        private INotificationService _notificationService;
        private IUserRepository _userRepository;
        private IWeeklyMenuService _weeklyMenuService;

        public AdminService(INotificationService notificationService, IFoodItemService foodItemService, IUserRepository userRepository, IWeeklyMenuService weeklyMenuService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
            _weeklyMenuService = weeklyMenuService;
            _foodItemService = foodItemService;
        }

        public async Task<string> AddFoodItem(string input)
        {
            //1 - Name : "" Price : "" FoodItemTypeId : ""
            var foodItem = new AddFoodItem();

            /*await SendMessageAsync(stream, "Enter the name of the food item:");
            foodItem.Name = await ReceiveMessageAsync(stream);

            await SendMessageAsync(stream, "Enter the price of the food item:");
            if (decimal.TryParse(await ReceiveMessageAsync(stream), out decimal price))
            {
                foodItem.Price = price;
            }
            else
            {
                await SendMessageAsync(stream, AppConstants.InvalidInputMessage);
                return;
            }

            await SendMessageAsync(stream, "Enter the food item type Id:");
            if (int.TryParse(await ReceiveMessageAsync(stream), out int foodItemTypeId))
            {
                foodItem.FoodItemTypeId = foodItemTypeId;
            }
            else
            {
                await SendMessageAsync(stream, AppConstants.InvalidInputMessage);
                return;
            }

            if (await _foodItemService.DoesFoodItemWithSameNameExists(foodItem.Name))
            {
                await SendMessageAsync(stream, "Food item with the same name already exists!");
                return;
            }

            await _foodItemService.Add(foodItem);
            await _notificationService.SendBatchNotifications(AppConstants.FoodItemAdded, AppConstants.ChefAndEmployeeRoles);
            await SendMessageAsync(stream, "Food item added to menu successfully!");*/
            return "";
        }

        public async Task<string> UpdateAvailabilityStatusForFoodItem()
        {
            //var foodItem = await GetFoodItemById(networkStream);

            Console.WriteLine("Enter the StatusId you wish to set for the food item:");
            if (!int.TryParse(Console.ReadLine(), out int statusId))
            {
                throw new InvalidInputException(AppConstants.InvalidInputMessage);
            }
            return "";
            // foodItem.StatusId = statusId;
            // await UpdateFoodItemAsync(foodItem, string.Format(AppConstants.FoodItemStatusUpdated, foodItem.Name));
        }

        public async Task<string> HandleChoice(string input)
        {
            //1-Price:50 Name:Pizza
            string[] choices = input.Split("-");
            string userChoice = choices[0];
            string requestedInput = choices[1];
            switch (userChoice)
            {
                case "1":
                    return await AddFoodItem(requestedInput);
                case "2":
                    return await RemoveFoodItem();
                case "3":
                    return await BrowseTodayMenu();
                case "4":
                    return await UpdatePriceForFoodItem();
                case "5":
                    return await UpdateAvailabilityStatusForFoodItem();
                case "6":
                    return await BrowseMenu();
                    break;
                case "7":
                    // await SendMessageAsync(stream, "Logging out...");
                    // stream.Close();
                    return "";
                    break;
                default:
                    //  await SendMessageAsync(stream, "Invalid input. Please try again.");
                    return "";

            }
        }

        public string ShowAdminMenu()
        {
            return "\nSelect an option from the following:\n" +
                      "1. Add a new food item\n" +
                      "2. Remove food item\n" +
                      "3. View the daily menu\n" +
                      "4. Update the price of a food item\n" +
                      "5. Update the availability status of a food item\n" +
                      "6. Browse Menu of Cafeteria\n" +
                      "7. Logout\n" +
                      "Enter the number corresponding to your choice in the format: Admin 1-Name:Fries ";
        }

        public async Task<string> RemoveFoodItem()
        {
            // var foodItem = await GetFoodItemById(networkStream);
            // foodItem.StatusId = (int)Status.Unavailable;
            //await UpdateFoodItemAsync(foodItem, string.Format(AppConstants.FoodItemRemoved, foodItem.Name));
            return "";
        }

        public async Task<string> BrowseTodayMenu()
        {
            await _weeklyMenuService.GetDailyMenu();
            return "";
        }

        public async Task<string> BrowseMenu()
        {
            var foodItems = await _foodItemService.GetList<FoodItem>("MealType, FoodItemAvailabilityStatus, FoodItemType", null, null, 0, 0, null);
            foreach (var foodItem in foodItems)
            {
                Console.WriteLine($"Item : {foodItem.Name} \nFoodItemType : {foodItem.FoodItemType.Name} \nPrice : {foodItem.Price} \nFeedback : {foodItem.Description} \nStatus : {foodItem.FoodItemAvailabilityStatus.Name}");
                Console.WriteLine("\n");
            }
            return "";
        }

        public async Task<string> UpdatePriceForFoodItem()
        {
            //var foodItem = await GetFoodItemById(networkStream);

            Console.WriteLine("Enter the price you wish to set for the food item:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                throw new InvalidInputException(AppConstants.InvalidInputMessage);
            }

            // foodItem.Price = price;
            //await UpdateFoodItemAsync(foodItem, string.Format(AppConstants.FoodItemPriceUpdated, foodItem.Name));
            return "";
        }

        private async Task<FoodItem> GetFoodItemById()
        {
            Console.WriteLine("Enter the Id of the Food Item:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new InvalidInputException(AppConstants.InvalidInputMessage);
            }

            var foodItem = await _foodItemService.GetById<FoodItem>(id);
            if (foodItem == null)
            {
                throw new FoodItemNotFoundException(AppConstants.FoodItemNotFoundMessage);
            }

            return foodItem;
        }

        private async Task UpdateFoodItemAsync(FoodItem foodItem, string notificationMessage)
        {
            await _foodItemService.Update(foodItem.Id, foodItem);
            await _notificationService.SendBatchNotifications(notificationMessage, AppConstants.ChefAndEmployeeRoles);
            Console.WriteLine("Food item details have been updated successfully");
        }
    }
}
