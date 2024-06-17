using CafeteriaRecommendationSystem.Services.Interfaces;
using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IWeeklyMenuService : ICrudBaseService<WeeklyMenu>
    {
        Task CRONWeeklyMenuCleanUp();
        Task GetDailyMenu();
    }
}
