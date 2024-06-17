using AutoMapper;
using CMS.Common.Models;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;

namespace CMS.Data.Services
{
    public class AdminService : IAdminService
    {
        private IFoodItemService _foodItemService;
        private INotificationService _notificationService;
        private IUserRepository _userRepository;
        private IWeeklyMenuService _weeklyMenuService;
        private readonly IMapper _mapper;
        public AdminService(INotificationService notificationService, IFoodItemService foodItemService
            , IUserRepository userRepository, IWeeklyMenuService weeklyMenuService, IMapper mapper)
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

            Console.WriteLine("Enter the name of the food item:");
            foodItem.Name = Console.ReadLine();

            Console.WriteLine("Enter the price of the food item:");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                foodItem.Price = price;
            }
            else
            {
                Console.WriteLine("Invalid input for price. Operation aborted.");
                return;
            }

            Console.WriteLine("Enter the food item type ID");
            if (int.TryParse(Console.ReadLine(), out int foodItemTypeId))
            {
                foodItem.FoodItemTypeId = foodItemTypeId;
            }
            else
            {
                Console.WriteLine("Invalid input for food item type ID. Operation aborted.");
                return;
            }
            var foodItemEntity = _mapper.Map<FoodItem>(foodItem);
            await _foodItemService.Add(foodItemEntity);
        }

        public Task RemoveFoodItem()
        {
            //_foodItemService.Add<FoodItem>();
            throw new NotImplementedException();
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
                        RemoveFoodItem();
                        break;
                    case "3":
                        BrowseTodayMenu();
                        break;
                    case "4":
                        UpdateFoodItem();
                        break;
                    case "5":
                        UpdateFoodItem();
                        break;
                    case "6":
                        BrowseMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        public static void ShowAdminMenu()
        {
            Console.WriteLine("\nSelect an option from the following:");
            Console.WriteLine("1. Add a new food item");
            Console.WriteLine("2. Remove an existing food item");
            Console.WriteLine("3. View the daily menu");
            Console.WriteLine("4. Update the price of a food item");
            Console.WriteLine("5. Update the availability status of a food item");
            Console.WriteLine("6. Browse Menu of Cafeteria");
            Console.WriteLine("Enter the number corresponding to your choice:");
        }

        public Task UpdateFoodItem()
        {
            throw new NotImplementedException();
        }

        public Task BrowseTodayMenu()
        {
            //_weeklyMenuService.GetDailyMenu();
            throw new NotImplementedException();
        }

        public Task BrowseMenu()
        {
            //_weeklyMenuService.GetList() 
            throw new NotImplementedException();
        }
    }
}
