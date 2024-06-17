using CMS.Common.Enums;
using CMS.Data.Entities;
using Common.Enums;

namespace Data_Access_Layer
{
    public static class SeedData
    {
        public static List<Entities.Role> GetRoles()
        {
            return new List<Entities.Role>
            {
                new Entities.Role { Id = 1, Name = Common.Enums.Role.Admin.ToString() },
                new Entities.Role { Id = 2, Name = Common.Enums.Role.Chef.ToString() },
                new Entities.Role { Id = 3, Name = Common.Enums.Role.Employee.ToString() }
            };
        }

        public static List<Entities.FoodItemAvailabilityStatus> GetFoodItemAvailabilityStatus()
        {
            return new List<Entities.FoodItemAvailabilityStatus>
            {
                new Entities.FoodItemAvailabilityStatus { Id = 1, Name = Status.OutOfStock.ToString() },
                new Entities.FoodItemAvailabilityStatus { Id = 2, Name = Common.Enums.Status.Available.ToString() },
                new Entities.FoodItemAvailabilityStatus { Id = 3, Name = Common.Enums.Status.OnHold.ToString() }
            };
        }

        public static List<Entities.FoodItemType> GetFoodItemTypes()
        {
            return new List<Entities.FoodItemType>
            {
                new Entities.FoodItemType { Id = 1, Name = Common.Enums.FoodItemType.Appetizers.ToString() },
                new Entities.FoodItemType { Id = 2, Name = Common.Enums.FoodItemType.Salads.ToString() },
                new Entities.FoodItemType { Id = 3, Name = Common.Enums.FoodItemType.Sandwiches.ToString() },
                new Entities.FoodItemType { Id = 4, Name = Common.Enums.FoodItemType.MainCourses.ToString() },
                new Entities.FoodItemType { Id = 5, Name = Common.Enums.FoodItemType.Desserts.ToString() },
                new Entities.FoodItemType { Id = 6, Name = Common.Enums.FoodItemType.Beverages.ToString() },
            };
        }

        public static List<Entities.MealType> GetMealTypes()
        {
            return new List<Entities.MealType>
            {
                new Entities.MealType { Id = 1, Name = Common.Enums.MealType.Breakfast.ToString() },
                new Entities.MealType { Id = 2, Name = Common.Enums.MealType.Lunch.ToString() },
                new Entities.MealType { Id = 3, Name = Common.Enums.MealType.Dinner.ToString() }
            };
        }

        public static List<CMS.Data.Entities.NotificationType> GetNotificationTypes()
        {
            return new List<CMS.Data.Entities.NotificationType>
            {
                new CMS.Data.Entities.NotificationType { Id = 1, Name = CMS.Common.Enums.NotificationType.NewFoodItemAdded.ToString() },
                new CMS.Data.Entities.NotificationType { Id = 2, Name = CMS.Common.Enums.NotificationType.FoodItemRemoved.ToString()},
                new CMS.Data.Entities.NotificationType { Id = 3, Name = CMS.Common.Enums.NotificationType.FoodItemPriceUpdated.ToString() },
                new CMS.Data.Entities.NotificationType { Id = 4, Name = CMS.Common.Enums.NotificationType.FoodItemAvailabilityUpdated.ToString() },
                new CMS.Data.Entities.NotificationType { Id = 5, Name = CMS.Common.Enums.NotificationType.FoodItemVoting.ToString() },
                new CMS.Data.Entities.NotificationType { Id = 6, Name = CMS.Common.Enums.NotificationType.FinalMenu.ToString() },
            };
        }
    }
}
