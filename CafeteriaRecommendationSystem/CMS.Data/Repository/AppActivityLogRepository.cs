using CMS.Data.Repository.Interfaces;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Data.Entities;

namespace CMS.Data.Repository
{
    public class AppActivityLogRepository : CrudBaseRepository<AppActivityLog>, IAppActivityLogRepository
    {
        public AppActivityLogRepository(CMSDbContext context) : base(context)
        {
        }
        public async Task<DateTime?> GetLastExecutionDate(string settingName)
        {
            var setting = await _context.AppActivityLog.FindAsync(settingName);
            return setting?.Value;
        }
        public async Task UpdateLastExecutionDate(string settingName, DateTime value)
        {
            var setting = await _context.AppActivityLog.FindAsync(settingName);
            if (setting == null)
            {
                setting = new AppActivityLog
                {
                    ActionName = settingName,
                    Value = value,
                    ModifiedDateTime = DateTime.Now
                };
                _context.AppActivityLog.Add(setting);
            }
            else
            {
                setting.Value = value;
                setting.ModifiedDateTime = DateTime.Now;
            }
            await _context.SaveChangesAsync();
        }
        public async Task<bool> HasTaskExecutedThisMonth(string settingName)
        {
            var lastExecutionDate = await GetLastExecutionDate(settingName);
            return lastExecutionDate.HasValue && lastExecutionDate.Value.Month == DateTime.Now.Month && lastExecutionDate.Value.Year == DateTime.Now.Year;
        }
    }
}
