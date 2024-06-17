using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IFoodItemService : ICrudBaseService<FoodItem>
    {
        Task UpdatePrice(int foodItemId, decimal newPrice);
        Task UpdateMealType(int foodItemId, int newMealType);
        Task UpdateStatus(int foodItemId, int newStatus);
        Task<bool> DoesFoodItemWithSameNameExists(string name);
    }
}
