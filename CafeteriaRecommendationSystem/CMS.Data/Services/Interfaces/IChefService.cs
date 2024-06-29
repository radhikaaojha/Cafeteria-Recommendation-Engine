using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IChefService
    {
        Task<string> GetEmployeeVotes();
        Task<string> FinalizeMenuItems(string request);
        Task<string> PlanDailyMenu(string request);
        Task<string> GetTopRecommendations();
    }
}
