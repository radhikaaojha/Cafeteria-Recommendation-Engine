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
        Task<string> AddFoodItem(string input);
        Task<string> RemoveFoodItem(string request);
        Task<string> UpdateAvailabilityStatusForFoodItem(string request);
        Task<string> UpdatePriceForFoodItem(string request);
    }
}
