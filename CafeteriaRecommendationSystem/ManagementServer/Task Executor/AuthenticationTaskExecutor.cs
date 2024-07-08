using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Exceptions;
using CMS.Common.Models;
using CMS.Common.Utils;
using Common.Models;
using System.Text;
using System.Text.Json;

namespace Common.Utils
{
    public class AuthenticationTaskExecutor : ITaskExecutor
    {
        private IAuthenticateService _authenticateService;

        public AuthenticationTaskExecutor(IAuthenticateService authenticateService)
        {
            this._authenticateService = authenticateService;
        }

        public async Task<string> ExecuteTask(string action, string jsonRequest)
        {
            try
            {
                var userCredentials = JsonSerializer.Deserialize<LoginRequest>(jsonRequest);
                var loginResponse = await _authenticateService.Login(userCredentials);

                return ProtocolResponseHelper.CreateSuccessResponse(JsonSerializer.Serialize(loginResponse),action);
            }
            catch (UserNotFoundException e)
            {
                LoginResponse exceptionResponse = new();
                exceptionResponse.Message = e.Message;
                var exceptionResponseJson = JsonSerializer.Serialize(exceptionResponse);
                CustomProtocol customProtocolDTO = new CustomProtocol();
                customProtocolDTO.Response = exceptionResponseJson;
                return JsonSerializer.Serialize(customProtocolDTO);
            }
            catch (Exception ex)
            {
                return ProtocolResponseHelper.CreateFailureResponse(ex.Message);
            }
        }

        
    }
}
