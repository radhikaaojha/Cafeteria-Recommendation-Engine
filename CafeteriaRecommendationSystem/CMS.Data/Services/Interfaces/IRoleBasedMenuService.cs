using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Services.Interfaces
{
    public interface IRoleBasedMenuService
    {
        Task<string> ViewOptions(int roleId);
    }
}
