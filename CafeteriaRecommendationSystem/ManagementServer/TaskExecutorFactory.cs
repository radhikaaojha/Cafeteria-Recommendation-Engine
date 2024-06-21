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
    public class TaskExecutorFactory
    {
        private readonly Dictionary<string, ITaskExecutor> taskExecutors;
        public TaskExecutorFactory(IAuthenticateService authenticateService, IUserRepository userRepository, IAdminService adminService, IChefService chefService, IEmployeeService employeeService)
        {
            taskExecutors = new Dictionary<string, ITaskExecutor>
        {
                { Actions.Auth.ToString(), new AuthenticateTaskExecutor(authenticateService,userRepository) },
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

    public interface ITaskExecutor
    {
        Task<string> ExecuteTask(string action,string JsonRequest);
    }


    public class AuthenticateTaskExecutor : ITaskExecutor
    {
        private IAuthenticateService authenticateService;
        private IUserRepository userRepository;

        public AuthenticateTaskExecutor(IAuthenticateService authenticateService, IUserRepository userRepository)
        {
            this.authenticateService = authenticateService;
            this.userRepository = userRepository;
        }

        public async Task<string> ExecuteTask(string action,string jsonRequest)
        {
            var userCredentials = JsonSerializer.Deserialize<UserLogin>(jsonRequest);
            var loginResponse = await authenticateService.Login(userCredentials);

            if (loginResponse.IsAuthenticated)
            {
                return CreateSuccessResponse(JsonSerializer.Serialize(loginResponse));
            }
            else
            {
                return CreateFailureResponse(loginResponse.Message);
            }
        }
        private string CreateSuccessResponse(string response)
        {
            var successResponse = new CustomProtocolDTO
            {
                Response = response,
                Action = "Sucess" 
            };

            return JsonSerializer.Serialize(successResponse);
        }

        private string CreateFailureResponse(string message)
        {
            var failureResponse = new CustomProtocolDTO
            {
                Payload ="false" ,
                Response = AppConstants.LoginFailed,
                Action = message 
            };

            return JsonSerializer.Serialize(failureResponse);
        }

    }

    public class AdminTaskExecutor : ITaskExecutor
    {
        private IAdminService adminService;

        public AdminTaskExecutor(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public async Task<string> ExecuteTask(string action, string request)
        {
            string response = string.Empty;
            
            switch (action)
            {
                case "AddFoodItem":
                    response = await adminService.AddFoodItem(request);
                    break;
                case "RemoveFoodItem":
                    response = await adminService.RemoveFoodItem(int.Parse(request));
                    break;
                case "UpdateFoodItemPrice":
                    response = await adminService.UpdatePriceForFoodItem(request);
                    break;
                case "UpdateFoodItemStatus":
                    response = await adminService.UpdateAvailabilityStatusForFoodItem(request);
                    break;
                case "BrowseMenu":
                    response = await adminService.BrowseMenu();
                    break;
            }
            return CreateSuccessResponse(response);
        }

        private string CreateSuccessResponse(string response)
        {
            var successResponse = new CustomProtocolDTO
            {
                Response = response,
                Action = "Sucess" 
            };

            return JsonSerializer.Serialize(successResponse);
        }

    }
}
