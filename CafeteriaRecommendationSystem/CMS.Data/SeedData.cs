using CMS.Common.Utils;
using Common.Enums;
using Data_Access_Layer.Entities;
using FoodItemType = Common.Enums.FoodItemType;

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
                new Entities.FoodItemAvailabilityStatus { Id = 3, Name = Common.Enums.Status.OnHold.ToString() },
                new Entities.FoodItemAvailabilityStatus { Id = 4, Name = Common.Enums.Status.Unavailable.ToString() }
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

        public static List<User> GetUsers()
        {
            var users = new List<User>
            {
            new User { Id = 1, Email = "admin1@example.com", Name = "Admin", RoleId = 1 },
            new User { Id = 2, Email = "admin2@example.com", Name = "Admin", RoleId = 1 },
            new User { Id = 3, Email = "admin3@example.com", Name = "Admin", RoleId = 1 },
            new User { Id = 4, Email = "user1@example.com", Name = "Radhika", RoleId = 2 },
            new User { Id = 5, Email = "user2@example.com", Name = "Raghvendra", RoleId = 2 },
            new User { Id = 6, Email = "user3@example.com", Name = "Rakshita", RoleId = 2 },
            new User { Id = 7, Email = "user4@example.com", Name = "Mukul", RoleId = 2 },
            new User { Id = 8, Email = "chef1@example.com", Name = "Amit", RoleId = 3 },
            new User { Id = 9, Email = "chef2@example.com", Name = "Ashit", RoleId = 3 },
            new User { Id = 10, Email = "chef3@example.com", Name = "Ankit", RoleId = 3 }

            };

            foreach (var user in users)
            {
                user.Salt = PasswordHelper.GenerateSalt(16);
                user.Password = PasswordHelper.HashPassword("1234", user.Salt);
            }
            return users;
        }

        public static FoodItem[] GetFoodItems()
        {
            return new FoodItem[]
        {
            // Appetizers
            new FoodItem { Id = 1, Name = "Samosa", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Appetizers },
            new FoodItem { Id = 2, Name = "Pakora", StatusId = 2, Price = 55, FoodItemTypeId = (int)FoodItemType.Appetizers },
            new FoodItem { Id = 3, Name = "Aloo Tikki", StatusId = 2, Price = 60, FoodItemTypeId = (int)Common.Enums.FoodItemType.Appetizers },
            new FoodItem { Id = 4, Name = "Paneer Tikka", StatusId = 2, Price = 95, FoodItemTypeId = (int)FoodItemType.Appetizers },
            new FoodItem { Id = 5, Name = "Bhel Puri", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Appetizers },

            // Salads
            new FoodItem { Id = 6, Name = "Kachumber Salad", StatusId = 2, Price = 60, FoodItemTypeId = (int)FoodItemType.Salads },
            new FoodItem { Id = 7, Name = "Green Salad", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Salads },
            new FoodItem { Id = 8, Name = "Sprout Salad", StatusId = 2, Price = 65, FoodItemTypeId = (int)FoodItemType.Salads },
            new FoodItem { Id = 9, Name = "Chickpea Salad", StatusId = 2, Price = 70, FoodItemTypeId = (int)FoodItemType.Salads },
            new FoodItem { Id = 10, Name = "Cucumber Raita", StatusId = 2, Price = 55, FoodItemTypeId = (int)FoodItemType.Salads },

            // Sandwiches
            new FoodItem { Id = 11, Name = "Vegetable Sandwich", StatusId = 2, Price = 75, FoodItemTypeId = (int)FoodItemType.Sandwiches },
            new FoodItem { Id = 12, Name = "Paneer Sandwich", StatusId = 2, Price = 85, FoodItemTypeId = (int)FoodItemType.Sandwiches },
            new FoodItem { Id = 13, Name = "Chicken Sandwich", StatusId = 2, Price = 90, FoodItemTypeId = (int)FoodItemType.Sandwiches },
            new FoodItem { Id = 14, Name = "Egg Sandwich", StatusId = 2, Price = 80, FoodItemTypeId = (int)FoodItemType.Sandwiches },
            new FoodItem { Id = 15, Name = "Cheese Sandwich", StatusId = 2, Price = 85, FoodItemTypeId = (int)FoodItemType.Sandwiches },

            // Main Courses
            new FoodItem { Id = 16, Name = "Butter Chicken", StatusId = 2, Price = 150, FoodItemTypeId = (int)FoodItemType.MainCourses },
            new FoodItem { Id = 17, Name = "Paneer Butter Masala", StatusId = 2, Price = 130, FoodItemTypeId = (int)FoodItemType.MainCourses },
            new FoodItem { Id = 18, Name = "Dal Makhani", StatusId = 2, Price = 100, FoodItemTypeId = (int)FoodItemType.MainCourses },
            new FoodItem { Id = 19, Name = "Chole Bhature", StatusId = 2, Price = 110, FoodItemTypeId = (int)FoodItemType.MainCourses },
            new FoodItem { Id = 20, Name = "Biryani", StatusId = 2, Price = 120, FoodItemTypeId = (int)FoodItemType.MainCourses },

            // Desserts
            new FoodItem { Id = 21, Name = "Gulab Jamun", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Desserts },
            new FoodItem { Id = 22, Name = "Rasgulla", StatusId = 2, Price = 60, FoodItemTypeId = (int)FoodItemType.Desserts },
            new FoodItem { Id = 23, Name = "Jalebi", StatusId = 2, Price = 55, FoodItemTypeId = (int)FoodItemType.Desserts },
            new FoodItem { Id = 24, Name = "Kheer", StatusId = 2, Price = 65, FoodItemTypeId = (int)FoodItemType.Desserts },
            new FoodItem { Id = 25, Name = "Halwa", StatusId = 2, Price = 70, FoodItemTypeId = (int)FoodItemType.Desserts },

            // Beverages
            new FoodItem { Id = 26, Name = "Masala Chai", StatusId = 2, Price = 30, FoodItemTypeId = (int)FoodItemType.Beverages },
            new FoodItem { Id = 27, Name = "Lassi", StatusId = 2, Price = 40, FoodItemTypeId = (int)FoodItemType.Beverages },
            new FoodItem { Id = 28, Name = "Nimbu Pani", StatusId = 2, Price = 35, FoodItemTypeId = (int)FoodItemType.Beverages },
            new FoodItem { Id = 29, Name = "Mango Shake", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Beverages },
            new FoodItem { Id = 30, Name = "Coconut Water", StatusId = 2, Price = 45, FoodItemTypeId = (int)FoodItemType.Beverages }
        };
        }
    }
}
