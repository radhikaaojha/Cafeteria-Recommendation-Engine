using AutoMapper;
using CafeteriaRecommendationSystem.Services;
using CMS.Data.Services.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services
{
    public class WeeklyMenuService : CrudBaseService<WeeklyMenu>, IWeeklyMenuService
    {
        private IFeedbackService _feedbackService;
        public WeeklyMenuService(ICrudBaseRepository<WeeklyMenu> repository, IFeedbackService feedbackService, IMapper mapper) : base(repository, mapper)
        {
            _feedbackService = feedbackService;
        }

        public async Task WeeklyMenuCleanUp()
        {
            var oneWeekAgo = DateTime.Now.AddDays(-7);

            Expression<Func<WeeklyMenu, bool>> predicate = wm => wm.CreatedDateTime.Date < oneWeekAgo.Date;

            var currentWeekMenu = await base.GetList<WeeklyMenu>(null, null, null, 0, 0, predicate);

            await base.DeleteRange(currentWeekMenu);
        }
    }
}
