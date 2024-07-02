using CMS.Common.Utils;
using CMS.Data.Entities;
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
                new Entities.FoodItemAvailabilityStatus { Id = 4, Name = Common.Enums.Status.Unavailable.ToString() },
                new Entities.FoodItemAvailabilityStatus { Id = 5, Name = Common.Enums.Status.Discarded.ToString() },
                new Entities.FoodItemAvailabilityStatus { Id = 6, Name = Common.Enums.Status.Removed.ToString() }
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
                new CMS.Data.Entities.NotificationType { Id = 7, Name = CMS.Common.Enums.NotificationType.DetailedFeedback.ToString() },
            };
        }

        public static List<User> GetUsers()
        {
            var users = new List<User>
            {
            new User { Id = 1, Email = "admin1@example.com", Name = "Admin", RoleId = 1 },
            new User { Id = 2, Email = "admin2@example.com", Name = "Admin", RoleId = 1 },
            new User { Id = 3, Email = "admin3@example.com", Name = "Admin", RoleId = 1 },
            new User { Id = 4, Email = "user1@example.com", Name = "Radhika", RoleId = 3 },
            new User { Id = 5, Email = "user2@example.com", Name = "Raghvendra", RoleId = 3 },
            new User { Id = 6, Email = "user3@example.com", Name = "Rakshita", RoleId = 3 },
            new User { Id = 7, Email = "user4@example.com", Name = "Mukul", RoleId = 3 },
            new User { Id = 8, Email = "chef1@example.com", Name = "Amit", RoleId = 2 },
            new User { Id = 9, Email = "chef2@example.com", Name = "Ashit", RoleId = 2 },
            new User { Id = 10, Email = "chef3@example.com", Name = "Ankit", RoleId = 2 }

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
            new FoodItem { Id = 1, Name = "Samosa", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Appetizers, },
            new FoodItem { Id = 2, Name = "Pakora", StatusId = 2, Price = 55, FoodItemTypeId = (int)FoodItemType.Appetizers ,},
            new FoodItem { Id = 3, Name = "Aloo Tikki", StatusId = 2, Price = 60, FoodItemTypeId = (int)Common.Enums.FoodItemType.Appetizers,},
            new FoodItem { Id = 4, Name = "Paneer Tikka", StatusId = 2, Price = 95, FoodItemTypeId = (int)FoodItemType.Appetizers ,},
            new FoodItem { Id = 5, Name = "Bhel Puri", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Appetizers ,},

            // Salads
            new FoodItem { Id = 6, Name = "Kachumber Salad", StatusId = 2, Price = 60, FoodItemTypeId = (int)FoodItemType.Salads,},
            new FoodItem { Id = 7, Name = "Green Salad", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Salads,},
            new FoodItem { Id = 8, Name = "Sprout Salad", StatusId = 2, Price = 65, FoodItemTypeId = (int)FoodItemType.Salads ,},
            new FoodItem { Id = 9, Name = "Chickpea Salad", StatusId = 2, Price = 70, FoodItemTypeId = (int)FoodItemType.Salads,},
            new FoodItem { Id = 10, Name = "Cucumber Raita", StatusId = 2, Price = 55, FoodItemTypeId = (int)FoodItemType.Salads,},

            // Sandwiches
            new FoodItem { Id = 11, Name = "Vegetable Sandwich", StatusId = 2, Price = 75, FoodItemTypeId = (int)FoodItemType.Sandwiches,},
            new FoodItem { Id = 12, Name = "Paneer Sandwich", StatusId = 2, Price = 85, FoodItemTypeId = (int)FoodItemType.Sandwiches,},
            new FoodItem { Id = 13, Name = "Chicken Sandwich", StatusId = 2, Price = 90, FoodItemTypeId = (int)FoodItemType.Sandwiches,},
            new FoodItem { Id = 14, Name = "Egg Sandwich", StatusId = 2, Price = 80, FoodItemTypeId = (int)FoodItemType.Sandwiches,},
            new FoodItem { Id = 15, Name = "Cheese Sandwich", StatusId = 2, Price = 85, FoodItemTypeId = (int)FoodItemType.Sandwiches ,},

            // Main Courses
            new FoodItem { Id = 16, Name = "Chole Rice", StatusId = 2, Price = 150, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 17, Name = "Rajma Rice", StatusId = 2, Price = 130, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 18, Name = "Paneer Roti", StatusId = 2, Price = 100, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 19, Name = "Chole Bhature", StatusId = 2, Price = 110, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 20, Name = "Biryani", StatusId = 2, Price = 120, FoodItemTypeId = (int)FoodItemType.MainCourses,},

            // Desserts
            new FoodItem { Id = 21, Name = "Gulab Jamun", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Desserts ,},
            new FoodItem { Id = 22, Name = "Rasgulla", StatusId = 2, Price = 60, FoodItemTypeId = (int)FoodItemType.Desserts,},
            new FoodItem { Id = 23, Name = "Jalebi", StatusId = 2, Price = 55, FoodItemTypeId = (int)FoodItemType.Desserts,},
            new FoodItem { Id = 24, Name = "Kheer", StatusId = 2, Price = 65, FoodItemTypeId = (int)FoodItemType.Desserts ,},
            new FoodItem { Id = 25, Name = "Halwa", StatusId = 2, Price = 70, FoodItemTypeId = (int)FoodItemType.Desserts,},

            // Beverages
            new FoodItem { Id = 26, Name = "Masala Chai", StatusId = 2, Price = 30, FoodItemTypeId = (int)FoodItemType.Beverages,},
            new FoodItem { Id = 27, Name = "Lassi", StatusId = 2, Price = 40, FoodItemTypeId = (int)FoodItemType.Beverages ,},
            new FoodItem { Id = 28, Name = "Nimbu Pani", StatusId = 2, Price = 35, FoodItemTypeId = (int)FoodItemType.Beverages,},
            new FoodItem { Id = 29, Name = "Mango Shake", StatusId = 2, Price = 50, FoodItemTypeId = (int)FoodItemType.Beverages},
            new FoodItem { Id = 30, Name = "Coconut Water", StatusId = 2, Price = 45, FoodItemTypeId = (int)FoodItemType.Beverages,},
            
            new FoodItem { Id = 31, Name = "Lotus Biscoff Pastry", StatusId = 2, Price = 80, FoodItemTypeId = (int)FoodItemType.Desserts },
            new FoodItem { Id = 32, Name = "Tiramisu", StatusId = 2, Price = 90, FoodItemTypeId = (int)FoodItemType.Desserts },

            //Thalis
             new FoodItem { Id = 33, Name = "Mixed Veg Roti", StatusId = 2, Price = 150, FoodItemTypeId = (int)FoodItemType.MainCourses,},
             new FoodItem { Id = 34, Name = "Kadhi Rice", StatusId = 2, Price = 120, FoodItemTypeId = (int)FoodItemType.MainCourses,},
             new FoodItem { Id = 35, Name = "Masoor Dal Rice", StatusId = 2, Price = 110, FoodItemTypeId = (int)FoodItemType.MainCourses,},
             new FoodItem { Id = 36, Name = "Chicken Curry Rice", StatusId = 2, Price = 180, FoodItemTypeId = (int)FoodItemType.MainCourses,},
             new FoodItem { Id = 37, Name = "Egg Curry Rice", StatusId = 2, Price = 160, FoodItemTypeId = (int)FoodItemType.MainCourses,},
             new FoodItem { Id = 38, Name = "Dal Roti", StatusId = 2, Price = 100, FoodItemTypeId = (int)FoodItemType.MainCourses ,},
             new FoodItem { Id = 39, Name = "Mutton Biryani", StatusId = 2, Price = 100, FoodItemTypeId = (int)FoodItemType.MainCourses,},
             new FoodItem { Id = 40, Name = "Fish Curry Rice", StatusId = 2, Price = 190, FoodItemTypeId = (int)FoodItemType.MainCourses ,},
            new FoodItem { Id = 41, Name = "Mutton Curry Rice", StatusId = 2, Price = 220, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 42, Name = "Vegetable Pulao", StatusId = 2, Price = 130, FoodItemTypeId = (int)FoodItemType.MainCourses ,},
            new FoodItem { Id = 43, Name = "Aloo Gobi Roti", StatusId = 2, Price = 120, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 44, Name = "Baingan Bharta Roti", StatusId = 2, Price = 130, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 45, Name = "Palak Paneer Roti", StatusId = 2, Price = 150, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 46, Name = "Sambar Rice", StatusId = 2, Price = 100, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 47, Name = "Aloo Matar Roti", StatusId = 2, Price = 120, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 48, Name = "Gobi Masala Roti", StatusId = 2, Price = 140, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 49, Name = "Paneer Bhurji Roti", StatusId = 2, Price = 160, FoodItemTypeId = (int)FoodItemType.MainCourses,},
            new FoodItem { Id = 50, Name = "Chicken Biryani", StatusId = 2, Price = 200, FoodItemTypeId = (int)FoodItemType.MainCourses ,},
            new FoodItem { Id = 51, Name = "Aloo Paratha", StatusId = 2, Price = 110, FoodItemTypeId = (int)FoodItemType.MainCourses ,},
             new FoodItem { Id = 52, Name = "Bhindi Roti", StatusId = 2, Price = 140, FoodItemTypeId = (int)FoodItemType.MainCourses,},

        };
        }
        public static FoodItemCharacteristic[] GetFoodItemCharacterstic()
        {
            return new FoodItemCharacteristic[]
        {
            new FoodItemCharacteristic { Id = 1, Name = "Vegetarian" },
            new FoodItemCharacteristic { Id = 2, Name = "Non Vegetarian" },
            new FoodItemCharacteristic { Id = 3, Name = "Eggetarian" },
            new FoodItemCharacteristic { Id = 4, Name = "High Spicy" },
            new FoodItemCharacteristic { Id = 5, Name = "Medium Spicy" },
            new FoodItemCharacteristic { Id = 6, Name = "Low Spicy" },
            new FoodItemCharacteristic { Id = 7, Name = "North Indian Cuisine" },
            new FoodItemCharacteristic { Id = 8, Name = "South Indian Cuisine" },
            new FoodItemCharacteristic { Id = 9, Name = "Other Cuisine" },
            new FoodItemCharacteristic { Id = 11, Name = "Sweet tooth" },
            new FoodItemCharacteristic { Id = 10, Name = "Not a sweet tooth" }

        };
        }
        public static FoodItemCharactersticMapping[] GetFoodItemCharactersticMapping()
        {
            return new FoodItemCharactersticMapping[]
        {
                     // Samosa
            new FoodItemCharactersticMapping { Id =1,FoodItemId = 1, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =2,FoodItemId = 1, CharacteristicId = 4 },
            new FoodItemCharactersticMapping { Id =3,FoodItemId = 1, CharacteristicId = 7 },
    
            // Pakora
            new FoodItemCharactersticMapping { Id =4,FoodItemId = 2, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =5,FoodItemId = 2, CharacteristicId = 5 },
            new FoodItemCharactersticMapping { Id =6,FoodItemId = 2, CharacteristicId = 7 },

            // Aloo Tikki
            new FoodItemCharactersticMapping { Id =7,FoodItemId = 3, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =8,FoodItemId = 3, CharacteristicId = 6 },
            new FoodItemCharactersticMapping { Id =9,FoodItemId = 3, CharacteristicId = 7 },

            // Paneer Tikka
            new FoodItemCharactersticMapping { Id =10,FoodItemId = 4, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =11,FoodItemId = 4, CharacteristicId = 4 },
            new FoodItemCharactersticMapping { Id =12,FoodItemId = 4, CharacteristicId = 8 },

            // Bhel Puri
            new FoodItemCharactersticMapping { Id =13,FoodItemId = 5, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =14,FoodItemId = 5, CharacteristicId = 5 },
            new FoodItemCharactersticMapping { Id =15,FoodItemId = 5, CharacteristicId = 7 },

            // Kachumber Salad
            new FoodItemCharactersticMapping { Id =16,FoodItemId = 6, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =17,FoodItemId = 6, CharacteristicId = 6 },

            // Green Salad
            new FoodItemCharactersticMapping { Id =18,FoodItemId = 7, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =19,FoodItemId = 7, CharacteristicId = 6 },

            // Sprout Salad
            new FoodItemCharactersticMapping { Id =20,FoodItemId = 8, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =21,FoodItemId = 8, CharacteristicId = 6 },

            // Chickpea Salad
            new FoodItemCharactersticMapping { Id =22,FoodItemId = 9, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id =23,FoodItemId = 9, CharacteristicId = 6 },

            // Cucumber Raita
            new FoodItemCharactersticMapping { Id =24,FoodItemId = 10, CharacteristicId = 1 },

            // Vegetable Sandwich
            new FoodItemCharactersticMapping { Id=25,FoodItemId = 11, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=26,FoodItemId = 11, CharacteristicId = 5 },
            new FoodItemCharactersticMapping { Id=27,FoodItemId = 11, CharacteristicId = 9 },
            new FoodItemCharactersticMapping { Id=28,FoodItemId = 11, CharacteristicId = 10 },
            // Paneer Sandwich
            new FoodItemCharactersticMapping { Id=29,FoodItemId = 12, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=30,FoodItemId = 12, CharacteristicId = 4 },
            new FoodItemCharactersticMapping { Id=31,FoodItemId = 12, CharacteristicId = 9 },
            new FoodItemCharactersticMapping { Id=32,FoodItemId = 12, CharacteristicId = 10 },

            // Chicken Sandwich
            new FoodItemCharactersticMapping { Id=33,FoodItemId = 13, CharacteristicId = 2 },
            new FoodItemCharactersticMapping { Id=34,FoodItemId = 13, CharacteristicId = 3 },
            new FoodItemCharactersticMapping { Id=35,FoodItemId = 13, CharacteristicId = 9 },
            new FoodItemCharactersticMapping { Id=36,FoodItemId = 13, CharacteristicId = 10 },

            // Egg Sandwich
            new FoodItemCharactersticMapping { Id=37,FoodItemId = 14, CharacteristicId = 2 },
            new FoodItemCharactersticMapping { Id=38,FoodItemId = 14, CharacteristicId = 3 },
            new FoodItemCharactersticMapping { Id=39,FoodItemId = 14, CharacteristicId = 9 },
            new FoodItemCharactersticMapping { Id=40,FoodItemId = 14, CharacteristicId = 10 },

            // Cheese Sandwich
            new FoodItemCharactersticMapping { Id=41,FoodItemId = 15, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=42,FoodItemId = 15, CharacteristicId = 4 },
            new FoodItemCharactersticMapping { Id=43,FoodItemId = 15, CharacteristicId = 9 },
            new FoodItemCharactersticMapping { Id=44,FoodItemId = 15, CharacteristicId = 10 },

            // Chole Rice
            new FoodItemCharactersticMapping { Id=45,FoodItemId = 16, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=46,FoodItemId = 16, CharacteristicId = 4 },

            // Rajma Rice
            new FoodItemCharactersticMapping { Id=47,FoodItemId = 17, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=48,FoodItemId = 17, CharacteristicId = 4 },

            // Paneer Roti
            new FoodItemCharactersticMapping { Id=49,FoodItemId = 18, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=50,FoodItemId = 18, CharacteristicId = 4 },

            // Chole Bhature
            new FoodItemCharactersticMapping { Id=51,FoodItemId = 19, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=52,FoodItemId = 19, CharacteristicId = 4 },

            // Biryani
            new FoodItemCharactersticMapping { Id=53,FoodItemId = 20, CharacteristicId = 2 },
            new FoodItemCharactersticMapping { Id=54,FoodItemId = 20, CharacteristicId = 3 },

            // Gulab Jamun
            new FoodItemCharactersticMapping { Id=55,FoodItemId = 21, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=56,FoodItemId = 21, CharacteristicId = 5 },

            // Rasgulla
            new FoodItemCharactersticMapping { Id=57,FoodItemId = 22, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=58,FoodItemId = 22, CharacteristicId = 5 },

            // Jalebi
            new FoodItemCharactersticMapping { Id=59,FoodItemId = 23, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=60,FoodItemId = 23, CharacteristicId = 5 },

            // Kheer
            new FoodItemCharactersticMapping { Id=61,FoodItemId = 24, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=62,FoodItemId = 24, CharacteristicId = 5 },

            // Halwa
            new FoodItemCharactersticMapping { Id=63,FoodItemId = 25, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=64,FoodItemId = 25, CharacteristicId = 5 },

            // Masala Chai
            new FoodItemCharactersticMapping { Id=65,FoodItemId = 26, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=66,FoodItemId = 26, CharacteristicId = 6 },

            // Lassi
            new FoodItemCharactersticMapping { Id=67,FoodItemId = 27, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=68, FoodItemId = 27, CharacteristicId = 6 },

            // Nimbu Pani
            new FoodItemCharactersticMapping { Id=69,FoodItemId = 28, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=70,FoodItemId = 28, CharacteristicId = 6 },

            // Mango Shake
            new FoodItemCharactersticMapping { Id=71,FoodItemId = 29, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=72,FoodItemId = 29, CharacteristicId = 6 },

            // Coconut Water
            new FoodItemCharactersticMapping { Id=73,FoodItemId = 30, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=74,FoodItemId = 30, CharacteristicId = 6 },

            new FoodItemCharactersticMapping { Id=75,FoodItemId = 31, CharacteristicId = 3 }, 
            new FoodItemCharactersticMapping { Id=76,FoodItemId = 31, CharacteristicId = 11 }, 

            new FoodItemCharactersticMapping { Id=77,FoodItemId = 32, CharacteristicId = 3 }, 
            new FoodItemCharactersticMapping { Id=78,FoodItemId = 32, CharacteristicId = 11 }, 

            new FoodItemCharactersticMapping { Id=79,FoodItemId = 33, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=80,FoodItemId = 33, CharacteristicId = 7 },
            new FoodItemCharactersticMapping {Id = 81,  FoodItemId = 34, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=82,FoodItemId = 34, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=83,FoodItemId = 35, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=84,FoodItemId = 35, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=85,FoodItemId = 36, CharacteristicId = 2 },
            new FoodItemCharactersticMapping { Id=86,FoodItemId = 36, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=87,FoodItemId = 37, CharacteristicId = 3 },
            new FoodItemCharactersticMapping { Id=88,FoodItemId = 37, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=89,FoodItemId = 38, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=90,FoodItemId = 38, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=91,FoodItemId = 39, CharacteristicId = 2 },
            new FoodItemCharactersticMapping { Id=92,FoodItemId = 39, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=93,FoodItemId = 40, CharacteristicId = 2 },
            new FoodItemCharactersticMapping { Id=94,FoodItemId = 40, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=95,FoodItemId = 41, CharacteristicId = 2 },
            new FoodItemCharactersticMapping { Id=96,FoodItemId = 41, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=97,FoodItemId = 42, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=98,FoodItemId = 42, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=99,FoodItemId = 43, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=100,FoodItemId = 43, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=101,FoodItemId = 44, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=102,FoodItemId = 44, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=103,FoodItemId = 45, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=104,FoodItemId = 45, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=105,FoodItemId = 46, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=106,FoodItemId = 46, CharacteristicId = 8 },
            new FoodItemCharactersticMapping { Id=107,FoodItemId = 47, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=108,FoodItemId = 47, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=109,FoodItemId = 48, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=110,FoodItemId = 48, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=111,FoodItemId = 49, CharacteristicId = 1 },
            new FoodItemCharactersticMapping { Id=112, FoodItemId = 49, CharacteristicId = 7 },
            new FoodItemCharactersticMapping { Id=113,FoodItemId = 50, CharacteristicId = 2 }
        };
        }
    }
}

