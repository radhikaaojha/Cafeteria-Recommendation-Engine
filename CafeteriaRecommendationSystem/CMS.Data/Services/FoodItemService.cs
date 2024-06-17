using CafeteriaRecommendationSystem.Services;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;

namespace CMS.Data.Services
{
    public class FoodItemService : CrudBaseService<FoodItem>, IFoodItemService
    {
        public FoodItemService(ICrudBaseRepository<FoodItem> repository) : base(repository)
        {
        }

        public Task UpdateMealType(int foodItemId, int newMealTypeId)
        {
            //base.GetById(foodItemId);
            //set newMealTypeId
            throw new NotImplementedException();
        }

        public Task UpdatePrice(int foodItemId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatus(int foodItemId, int newStatusId)
        {
            throw new NotImplementedException();
        }
    }
}
