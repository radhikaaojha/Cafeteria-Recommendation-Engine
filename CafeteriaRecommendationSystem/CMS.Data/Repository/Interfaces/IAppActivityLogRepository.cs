using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository.Interfaces
{
    public interface IAppActivityLogRepository
    {
        Task<DateTime?> GetLastExecutionDate(string settingName);
        Task UpdateLastExecutionDate(string settingName, DateTime value);
        Task<bool> HasTaskExecutedThisMonth(string settingName);
    }
}
