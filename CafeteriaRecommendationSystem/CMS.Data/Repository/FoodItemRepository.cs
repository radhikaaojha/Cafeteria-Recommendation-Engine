using CMS.Data.Repository.Interfaces;
using Data_Access_Layer;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository
{
    public class FoodItemRepository : CrudBaseRepository<FoodItem> , IFoodItemRepository
    {
        public FoodItemRepository(CMSDbContext context) : base(context)
        {
        }

        public async Task<bool> DoesFoodItemWithSameNameExists(string name)
        {
            return _context.FoodItem.Any(foodItem=>foodItem.Name == name);
        }
    }
}
