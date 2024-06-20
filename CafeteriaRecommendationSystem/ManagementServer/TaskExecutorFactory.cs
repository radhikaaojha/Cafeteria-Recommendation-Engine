using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Enums;
using CMS.Common.Models;
using CMS.Data.Services;
using CMS.Data.Services.Interfaces;
using Common.Models;
using Data_Access_Layer.Repository.Interfaces;
using System.Text.Json;

namespace CMS.Common.Utils
{
    public class TaskExecutorFactory
    {
        private readonly Dictionary<string, ITaskExecutor> taskExecutors;
        public TaskExecutorFactory(IAuthenticateService authenticateService, IUserRepository userRepository, IAdminService adminService)
        {
            taskExecutors = new Dictionary<string, ITaskExecutor>
        {
                { Actions.Auth.ToString(), new AuthenticateTaskExecutor(authenticateService,userRepository) },
                { Actions.AddFoodItem.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.RemoveFoodItem.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.UpdateFoodItemPrice.ToString(), new AdminTaskExecutor(adminService) },
                { Actions.UpdateFoodItemStatus.ToString(), new AdminTaskExecutor(adminService) },
           // { "AdminActions", new AdminTaskExecutor() }
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
                return CreateSuccessResponse(loginResponse.RoleId.ToString());
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
                   // return await adminService.RemoveFoodItem(request);
                case "3":
                   // return await adminService.BrowseTodayMenu(request);
                case "4":
                   // return await adminService.UpdatePriceForFoodItem();
                case "5":
                  //  return await UpdateAvailabilityStatusForFoodItem();
                case "6":
                  //  return await BrowseMenu();
                  //  break;
                case "7":
                default:
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
