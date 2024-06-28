using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Models;
using CMS.Common.Utils;
using Common.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Common.Utils
{
    public class AuthenticationTaskExecutor : ITaskExecutor
    {
        private IAuthenticateService authenticateService;

        public AuthenticationTaskExecutor(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        public async Task<string> ExecuteTask(string action, string jsonRequest)
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
                Payload = "false",
                Response = AppConstants.LoginFailed,
                Action = message
            };

            return JsonSerializer.Serialize(failureResponse);
        }

    }
}
