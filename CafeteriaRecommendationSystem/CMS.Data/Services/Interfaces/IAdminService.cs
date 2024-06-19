using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IAdminService
    {
        Task<string> HandleChoice(string choice);
        Task<string> AddFoodItem(string input);
        Task<string> RemoveFoodItem();
        Task<string> UpdateAvailabilityStatusForFoodItem();
        Task<string> UpdatePriceForFoodItem();
        Task<string> BrowseTodayMenu();
        Task<string> BrowseMenu();
        string ShowAdminMenu();
    }
}
