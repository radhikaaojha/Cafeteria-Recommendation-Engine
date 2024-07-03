using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<string> GiveFeedback(string request);
        Task<string> ViewDailyMenu(DateTime date,int userId, Expression<Func<WeeklyMenu, bool>> predicate);
        Task<string> VoteInFavourForMenuItem(string request);
        Task<string> SubmitDetailedFeedback(string request);
        Task<string> SubmitUserPreference(string request);
    }
}
