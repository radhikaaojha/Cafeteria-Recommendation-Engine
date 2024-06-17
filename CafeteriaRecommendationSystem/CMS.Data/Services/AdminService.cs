using AutoMapper;
using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Common;
using Common.Enums;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace CMS.Data.Services
{
    public class AdminService : IAdminService
    {
        private IFoodItemService _foodItemService;
        private INotificationService _notificationService;
        private IUserRepository _userRepository;
        private IWeeklyMenuService _weeklyMenuService;
        private readonly IMapper _mapper;

        public AdminService(INotificationService notificationService, IFoodItemService foodItemService, IUserRepository userRepository, IWeeklyMenuService weeklyMenuService, IMapper mapper)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
            _weeklyMenuService = weeklyMenuService;
            _foodItemService = foodItemService;
            _mapper = mapper;
        }

        public async Task AddFoodItem()
        {
            var foodItem = new AddFoodItem();

            Console.WriteLine("Enter the name of the food item :");
            foodItem.Name = Console.ReadLine();

            Console.WriteLine("Enter the price of the food item :");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                foodItem.Price = price;
            }
            else
            {
                throw new InvalidInputException(AppConstants.InvalidInputMessage);
            }

            Console.WriteLine("Enter the food item type Id :");
            if (int.TryParse(Console.ReadLine(), out int foodItemTypeId))
            {
                foodItem.FoodItemTypeId = foodItemTypeId;
            }
            else
            {
                throw new InvalidInputException(AppConstants.InvalidInputMessage);
            }
            if(await _foodItemService.DoesFoodItemWithSameNameExists(foodItem.Name))
            {
                throw new FoodItemExistsException("Food item with same name already exists!");
            }
            await _foodItemService.Add(foodItem);
            await _notificationService.SendBatchNotifications(AppConstants.FoodItemAdded, AppConstants.ChefAndEmployeeRoles);
            Console.WriteLine("Food item added to menu succesfully!");
        }

        public async Task UpdateAvailabilityStatusForFoodItem()
        {
            var foodItem = await GetFoodItemByIdAsync();

            Console.WriteLine("Enter the StatusId you wish to set for the food item:");
            if (!int.TryParse(Console.ReadLine(), out int statusId))
            {
                throw new InvalidInputException(AppConstants.InvalidInputMessage);
            }

            foodItem.StatusId = statusId;
            await UpdateFoodItemAsync(foodItem,string.Format(AppConstants.FoodItemStatusUpdated,foodItem.Name));
        }

        public async Task<List<string>> ViewFunctionalities()
        {
            while (true)
            {
                ShowAdminMenu();
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await AddFoodItem();
                        break;
                    case "2":
                        await RemoveFoodItem();
                        break;
                    case "3":
                        await BrowseTodayMenu();
                        break;
                    case "4":
                        await UpdatePriceForFoodItem();
                        break;
                    case "5":
                        await UpdateAvailabilityStatusForFoodItem();
                        break;
                    case "6":
                        await BrowseMenu();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        throw new InvalidInputException(AppConstants.InvalidInputMessage);
                }
            }
        }

        public static void ShowAdminMenu()
        {
            Console.WriteLine("\nSelect an option from the following:");
            Console.WriteLine("1. Add a new food item");
            Console.WriteLine("2. Remove food item");
            Console.WriteLine("3. View the daily menu");
            Console.WriteLine("4. Update the price of a food item");
            Console.WriteLine("5. Update the availability status of a food item");
            Console.WriteLine("6. Browse Menu of Cafeteria");
            Console.WriteLine("7. Logout");
            Console.WriteLine("Enter the number corresponding to your choice:");
        }

        public async Task RemoveFoodItem()
        {
            var foodItem = await GetFoodItemByIdAsync();
            foodItem.StatusId = (int)Status.Unavailable;
            await UpdateFoodItemAsync(foodItem, string.Format(AppConstants.FoodItemRemoved, foodItem.Name));
        }

        public async Task BrowseTodayMenu()
        {
            await _weeklyMenuService.GetDailyMenu();
        }

        public async Task BrowseMenu()
        {
            var foodItems = await _foodItemService.GetList<FoodItem>("MealType, FoodItemAvailabilityStatus, FoodItemType", null,null, 0, 0, null); 
            foreach(var foodItem in foodItems)
            {
                Console.WriteLine($"Item : {foodItem.Name} \nFoodItemType : {foodItem.FoodItemType.Name} \nPrice : {foodItem.Price} \nFeedback : {foodItem.Description} \nStatus : {foodItem.FoodItemAvailabilityStatus.Name}");
                Console.WriteLine("\n");
            }
        }

        public async Task UpdatePriceForFoodItem()
        {
            var foodItem = await GetFoodItemByIdAsync();

            Console.WriteLine("Enter the price you wish to set for the food item:");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                throw new InvalidInputException(AppConstants.InvalidInputMessage);
            }

            foodItem.Price = price;
            await UpdateFoodItemAsync(foodItem, string.Format(AppConstants.FoodItemPriceUpdated, foodItem.Name));
        }

        private async Task<FoodItem> GetFoodItemByIdAsync()
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
