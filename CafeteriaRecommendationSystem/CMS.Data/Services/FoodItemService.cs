using AutoMapper;
using CafeteriaRecommendationSystem.Services;
using CMS.Data.Repository.Interfaces;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;

namespace CMS.Data.Services
{
    public class FoodItemService : CrudBaseService<FoodItem>, IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;
        public FoodItemService(IFoodItemRepository foodItemRepository,ICrudBaseRepository<FoodItem> repository, IMapper mapper) : base(repository, mapper)
        {
            _foodItemRepository = foodItemRepository;
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

        public async Task<bool> DoesFoodItemWithSameNameExists(string name)
        {
            return await _foodItemRepository.DoesFoodItemWithSameNameExists(name);
        }
    }
}
