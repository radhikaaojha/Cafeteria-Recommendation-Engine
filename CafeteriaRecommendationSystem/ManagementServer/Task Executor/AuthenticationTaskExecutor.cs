using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Models;
using CMS.Common.Utils;
using Common.Models;
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

            return CreateSuccessResponse(JsonSerializer.Serialize(loginResponse));
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
