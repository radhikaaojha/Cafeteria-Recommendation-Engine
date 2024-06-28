using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Enums;
using CMS.Common.Models;
using CMS.Data.Services;
using CMS.Data.Services.Interfaces;
using Common;
using Common.Models;
using Common.Utils;
using Data_Access_Layer.Repository.Interfaces;
using System.Text.Json;

namespace CMS.Common.Utils
{
    public interface ITaskExecutor
    {
        Task<string> ExecuteTask(string action, string JsonRequest);
    }

    public class TaskExecutorFactory
    {
        private readonly Dictionary<string, ITaskExecutor> taskExecutors;
        public TaskExecutorFactory(IAuthenticateService authenticateService,IAdminService adminService, IChefService chefService, IEmployeeService employeeService)
        {
            taskExecutors = new Dictionary<string, ITaskExecutor>
        {
                { Actions.Auth.ToString(), new AuthenticationTaskExecutor(authenticateService) },
                { Actions.AddFoodItem.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.RemoveFoodItem.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.UpdateFoodItemPrice.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.UpdateFoodItemStatus.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.BrowseMenu.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.TopRecommendations.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.PlanNextDayMenu.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.FinalizeMenu.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.ViewNotifications.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.ViewVotes.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.SubmitFeedback.ToString(), new EmployeeTaskExecutor(employeeService) },
                { Actions.VoteForMenu.ToString(), new EmployeeTaskExecutor(employeeService) },
                { Actions.ViewNextDayMenu.ToString(), new EmployeeTaskExecutor(employeeService) },
        };
        }

        public ITaskExecutor GetTaskExecutor(string action)
        {
            if (taskExecutors.TryGetValue(action, out ITaskExecutor taskExecutor))
            {
                return taskExecutor;
            }
            else
            {
                throw new ArgumentException($"Invalid action: {action}");
            }
        }
    }
 
}
