using CMS.Data.Services.Interfaces;
using Common.Enums;
using System.Net.Sockets;
using System.Text;

namespace CMS.Data.Services
{
    public class RoleBasedMenuService : IRoleBasedMenuService
    {
        private readonly IAdminService _adminService;
        private readonly IChefService _chefService;
        private readonly IEmployeeService _employeeService;

        public RoleBasedMenuService(IAdminService adminService, IChefService chefService, IEmployeeService employeeService)
        {
            _adminService = adminService;
            _chefService = chefService;
            _employeeService = employeeService;
        }

        public async Task<string> ViewOptions(int roleId)
        {
            switch (roleId)
            {
                case (int)Role.Admin:
                     return _adminService.ShowAdminMenu();
                    break;
                case (int)Role.Chef:
                    return _chefService.ViewMenu();
                    break;
                case (int)Role.Employee:
                    return _employeeService.ViewMenu();
                    break;
                default:
                    return "";
                    break;
            }
        }
    }
}
