using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Repository.Interfaces;

namespace CMS.Data.Services
{
    public class AdminService : IAdminService
    {
        private IFoodItemService _foodItemService;
        private INotificationService _notificationService;
        private IUserRepository _userRepository;
        private IWeeklyMenuService _weeklyMenuService;
        public AdminService(INotificationService notificationService, IFoodItemService foodItemService
            , IUserRepository userRepository, IWeeklyMenuService weeklyMenuService)
        {
            _userRepository = userRepository;
            _notificationService = notificationService;
            _weeklyMenuService = weeklyMenuService;
            _foodItemService = foodItemService;
        }

        public Task AddFoodItem()
        {
            //_foodItemService.Add<FoodItem>();
            //_userRepository.GetList();
            //_notificationService.SendBatchNotifications();
            throw new NotImplementedException();
        }

        public Task RemoveFoodItem()
        {
            //_foodItemService.Add<FoodItem>();
            throw new NotImplementedException();
        }

        public List<string> ViewFunctionalities()
        {
            Console.WriteLine("HERE");
            //switch menu
            throw new NotImplementedException();
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
