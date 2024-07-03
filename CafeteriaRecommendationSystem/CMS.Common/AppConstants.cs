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
        public const string SERVER_IP = "127.0.0.1";
        public const int PORT = 8000;
        public const string LoginSuccess = "Login successfull";
        public const string LoginFailed = "Unable to login user! Invalid name or employeeId";
        public const string InvalidInputMessage = "Invalid input. Operation aborted.";
        public const string FoodItemNotFoundMessage = "Food Item with specified ID doesnt exist.";
        public const string ConnectionString = "Data Source=ITT-RADHIKA-O;Initial Catalog=CafeteriaManagementSystem;Integrated Security=True";
        public const string FoodItemAdded = "A new Food item {0} has been added to the menu!";
        public static readonly List<int> ChefAndEmployeeRoles =new() { (int)Role.Employee, (int)Role.Chef };
        public static readonly List<int> Employee =new() { (int)Role.Employee };
        public const string FoodItemPriceUpdated = "Food item {0} price has been updated";
        public const string FoodItemStatusUpdated = "Food item {0} availability has been updated";
        public const string FoodItemRemoved = "Food item {0} has been discontinued.";
        public const string DataPathForTrainedModel = @"C:\Users\radhika.ojha\OneDrive - InTimeTec Visionsoft Pvt. Ltd.,\Desktop\Cafeteria Recommendation Engine\Cafeteria-Recommendation-Engine\CafeteriaRecommendationSystem\CMS.Data\Services\SentimentData.csv";
        public static List<string> NegativeKeywords = new()
        {
            "bad",
            "terrible",
            "awful",
            "gross",
            "oily",
            "too sweet",
            "bland",
            "tasteless",
            "disgusting",
            "overcooked",
            "undercooked",
            "unappetizing",
            "stale",
            "dry",
            "burnt",
            "soggy",
            "flavorless",
            "inedible",
            "unpleasant",
            "yuck"
        };
        public static List<string> PositiveKeywords = new()
        {
            "yummy",
            "delicious",
            "tasty",
            "amazing",
            "good",
            "fresh",
            "savory",
            "appetizing",
            "scrumptious",
            "mouthwatering",
            "satisfying",
            "flavorful",
            "exquisite",
            "delectable",
            "succulent",
            "perfect",
            "excellent",
            "wonderful",
            "loved",
            "pleasing"
        };

    }
}
