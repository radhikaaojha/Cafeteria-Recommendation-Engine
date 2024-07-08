
using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Exceptions;
using Common;
using Common.Models;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace CafeteriaRecommendationSystem.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;
        private ILogger<AuthenticateService> _logger;
        public AuthenticateService(IUserRepository userRepository, ILogger<AuthenticateService> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> Login(LoginRequest userLogin)
        {
            var user = await _userRepository.AuthenticateUser(userLogin);
            if (user == null)
                throw new UserNotFoundException(AppConstants.LoginFailed, null, _logger);

            return new LoginResponse
            {
                 IsAuthenticated = true,
                 RoleId = user.RoleId,
                 UserId = user.Id,
                 Message = AppConstants.LoginSuccess
            };

        }
    }

}
