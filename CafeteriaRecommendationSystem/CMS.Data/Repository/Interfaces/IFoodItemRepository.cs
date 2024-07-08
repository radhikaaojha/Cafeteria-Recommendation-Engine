using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository.Interfaces
{
    public interface IFoodItemRepository : ICrudBaseRepository<FoodItem>
    {
        Task<bool> DoesFoodItemWithSameNameExists(string name);
        Task<List<FoodItem>> GetNextDayMenuRecommendation();
        Task<List<FoodItem>> GetDiscardedFoodItems();
    }
}
