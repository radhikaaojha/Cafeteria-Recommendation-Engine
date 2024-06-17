using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class AppConstants
    {
        public const string LoginSuccess = "Login successfull";
        public const string LoginFailed = "Unable to login user! Invalid credentials or password";
        public const string InvalidInputMessage = "Invalid input. Operation aborted.";
        public const string FoodItemNotFoundMessage = "Food Item with specified ID doesnt exist.";
        public const string ConnectionString = "Data Source=ITT-RADHIKA-O;Initial Catalog=CafeteriaManagementSystem;Integrated Security=True";
        public const string FoodItemAdded = "A new Food item has been added to the menu!";
        public static readonly List<int> ChefAndEmployeeRoles =new() { (int)Role.Employee, (int)Role.Chef };
        public const string FoodItemPriceUpdated = "Food item {0} price has been updated";
        public const string FoodItemStatusUpdated = "Food item {0} availability has been updated";
        public const string FoodItemRemoved = "Food item {0} has been discontinued.";
}
}
