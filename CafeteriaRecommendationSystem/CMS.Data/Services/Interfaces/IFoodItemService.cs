﻿using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Models;
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
        Task<FoodItem> UpdatePrice(int foodItemId, decimal newPrice);
        Task<FoodItem> UpdateStatus(int foodItemId, int newStatus);
        Task<bool> DoesFoodItemWithSameNameExists(string name);
        Task<string> ViewMenu();
        Task<string> GenerateDiscardedFoodItemList();
        Task<string> RollOutFeedbackQuestionnaireForDiscardedItem();
        Task<string> RemoveDiscardedFoodItem(string request);
        Task<string> DiscardFoodItem(string request);
    }
}
