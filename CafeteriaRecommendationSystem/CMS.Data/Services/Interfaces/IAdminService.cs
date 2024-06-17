using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<string>> ViewFunctionalities();
        Task AddFoodItem();
        Task UpdateFoodItem();
        Task RemoveFoodItem();
        Task BrowseTodayMenu();
        Task BrowseMenu();
    }
}
