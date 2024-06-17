
using CMS.Common.Models;
using Common.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaRecommendationSystem.Services.Interfaces
{
    public interface IAuthenticateService 
    {
        Task<LoginResponse> Login(UserLogin userLogin);
    }
}
