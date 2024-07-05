using CMS.Common.Models;
using Common.Models;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Interfaces
{
    public interface IUserRepository : ICrudBaseRepository<User>
    {
        Task<User> AuthenticateUser(UserLogin userLogin);
        Task<bool> HasVotedToday(int userId);
        Task SetUsersVotingStatus(bool status);
        Task SubmitUserPreferences(List<UserPreferenceInput> userPreferences);
        Task SetVotingStatusForAUser(bool status, int userId);
    }

}
