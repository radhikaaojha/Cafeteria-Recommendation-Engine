using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IChefService
    {
        Task BrowseTodayMenu();
        void ViewFunctionalities();
        Task FinalizeMenuItems();
        Task NotifyEmployeesForFinalizeedMenu();    
        Task NotifyEmployeesForPlannedMenu();    
        Task PlanDailyMenu();
        Task ViewFeedbackReport();
        Task ViewNotifications(int userId);
        Task BrowseMenu();
    }
}
