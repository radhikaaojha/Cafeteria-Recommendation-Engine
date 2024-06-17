using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IRoleBasedMenuService
    {
        Task<List<string>> ViewOptions(int roleId);
    }
}
