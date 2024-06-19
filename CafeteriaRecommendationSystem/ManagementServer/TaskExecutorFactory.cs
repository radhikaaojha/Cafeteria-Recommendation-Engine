using CafeteriaRecommendationSystem.Services.Interfaces;
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
        public TaskExecutorFactory(IAuthenticateService authenticateService, IUserRepository userRepository, IRoleBasedMenuService roleBasedMenuService, IAdminService adminService)
        {
            taskExecutors = new Dictionary<string, ITaskExecutor>
        {
                { "Auth", new AuthenticateTaskExecutor(authenticateService,userRepository, roleBasedMenuService) },
                { "Admin", new AdminTaskExecutor(adminService) }
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
        Task<string> ExecuteTask(string JsonRequest);
    }


    public class AuthenticateTaskExecutor : ITaskExecutor
    {
        private IAuthenticateService authenticateService;
        private IUserRepository userRepository;
        private IRoleBasedMenuService menuService;

        public AuthenticateTaskExecutor(IAuthenticateService authenticateService, IUserRepository userRepository, IRoleBasedMenuService menuService)
        {
            this.authenticateService = authenticateService;
            this.userRepository = userRepository;
            this.menuService = menuService;
        }

        public async Task<string> ExecuteTask(string jsonRequest)
        {
            var userCredentials = JsonSerializer.Deserialize<UserLogin>(jsonRequest);
            var loginResponse = await authenticateService.Login(userCredentials);

            if (loginResponse.IsAuthenticated)
            {
                string menu = await menuService.ViewOptions(loginResponse.RoleId);
                return CreateSuccessResponse(menu);
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
                Response = new Dictionary<string, string>
            {
                { "Result", response}
            },
                Headers = new Dictionary<string, string>
            {
                { "Message", "Sucess" }
            }
            };

            return JsonSerializer.Serialize(successResponse);
        }

        private string CreateFailureResponse(string message)
        {
            var failureResponse = new CustomProtocolDTO
            {
                Payload = new Dictionary<string, string>
            {
                { "IsAuthenticated", "false" }
            },
                Headers = new Dictionary<string, string>
            {
                { "Message", message }
            }
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

        public async Task<string> ExecuteTask(string request)
        {
            //1-Price:50 Name:Pizza
            var response = await adminService.HandleChoice(request);
            return CreateSuccessResponse(response);
        }

        private string CreateSuccessResponse(string response)
        {
            var successResponse = new CustomProtocolDTO
            {
                Response = new Dictionary<string, string>
            {
                { "Result", response}
            },
                Headers = new Dictionary<string, string>
            {
                { "Message", "Sucess" }
            }
            };

            return JsonSerializer.Serialize(successResponse);
        }

        private string CreateFailureResponse(string message)
        {
            var failureResponse = new CustomProtocolDTO
            {
                Payload = new Dictionary<string, string>
            {
                { "IsAuthenticated", "false" }
            },
                Headers = new Dictionary<string, string>
            {
                { "Message", message }
            }
            };

            return JsonSerializer.Serialize(failureResponse);
        }


    }
}
