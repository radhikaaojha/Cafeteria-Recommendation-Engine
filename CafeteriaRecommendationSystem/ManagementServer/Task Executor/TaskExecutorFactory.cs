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
        private readonly Dictionary<string, ITaskExecutor> _taskExecutors;
        public TaskExecutorFactory(IAuthenticateService authenticateService,IAdminService adminService, IChefService chefService, IEmployeeService employeeService, INotificationService notificationService, IFoodItemService foodItemService)
        {
            _taskExecutors = new Dictionary<string, ITaskExecutor>
        {
                { Actions.Auth.ToString(), new AuthenticationTaskExecutor(authenticateService) },
                { Actions.AddFoodItem.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.RemoveFoodItem.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.UpdateFoodItemPrice.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.UpdateFoodItemStatus.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.ViewMenu.ToString(), new CommonTaskExecutor(notificationService, foodItemService) },
                { Actions.TopRecommendations.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.PlanNextDayMenu.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.FinalizeMenu.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.ViewNotifications.ToString(), new CommonTaskExecutor(notificationService, foodItemService) },
                { Actions.ViewVotes.ToString(), new ChefTaskExecutor(chefService) },
                { Actions.SubmitFeedback.ToString(), new EmployeeTaskExecutor(employeeService) },
                { Actions.VoteForMenu.ToString(), new EmployeeTaskExecutor(employeeService) },
                { Actions.ViewRolledOutItems.ToString(), new EmployeeTaskExecutor(employeeService) },
                { Actions.ViewTodaysMenu.ToString(), new EmployeeTaskExecutor(employeeService) },
                { Actions.ViewDiscardList.ToString(), new CommonTaskExecutor(notificationService,foodItemService) },
                { Actions.RollOutDetailedFeedbackQuestions.ToString(), new CommonTaskExecutor(notificationService,foodItemService) },
                { Actions.SubmitDetailedFeedback.ToString(), new EmployeeTaskExecutor(employeeService) },
                { Actions.RemoveDiscardedFoodItem.ToString(), new CommonTaskExecutor(notificationService,foodItemService) },
                { Actions.UserPreference.ToString(), new EmployeeTaskExecutor(employeeService)  },
                { Actions.Logout.ToString(),  new CommonTaskExecutor(notificationService,foodItemService) },
        };
        }

        public ITaskExecutor GetTaskExecutor(string action)
        {
            if (_taskExecutors.TryGetValue(action, out ITaskExecutor taskExecutor))
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
