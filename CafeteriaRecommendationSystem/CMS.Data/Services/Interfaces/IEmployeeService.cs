using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IEmployeeService
    {
        void ViewFunctionalities();
        Task GiveFeedback(int foodItemId, string feedback, int rating);
        Task VoteInFavourForMenuItem(int foodItemId);
        Task GetVotingItems();
        Task BrowseTodayMenu();
        Task ViewNotifications(int userId);
    }
}
