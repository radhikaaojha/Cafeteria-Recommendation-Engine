
using CafeteriaRecommendationSystem.Services.Interfaces;
using CMS.Common.Models;
using Common;
using Common.Models;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;

namespace CafeteriaRecommendationSystem.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> Login(UserLogin userLogin)
        {
            var user = await _userRepository.AuthenticateUser(userLogin);    
            if(user != null)
            {
                return new LoginResponse
                {
                    IsAuthenticated = true,
                    RoleId = user.RoleId,
                    UserId = user.Id,
                    Message = AppConstants.LoginSuccess
                };
            }
            return new LoginResponse { IsAuthenticated = false , Message = AppConstants.LoginFailed };
        } 
    }

}
