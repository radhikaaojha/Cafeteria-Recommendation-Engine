using CMS.Data.Services.Interfaces;
using Common.Enums;

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

        public async Task<List<string>> ViewOptions(int roleId)
        {
            switch (roleId)
            {
                case (int)Role.Admin:
                    return await _adminService.ViewFunctionalities();
                case (int)Role.Chef:
                    _chefService.ViewFunctionalities();
                    return null;
                case (int)Role.Employee:
                    _employeeService.ViewFunctionalities();
                    return null;
                default:
                    Console.WriteLine("Unknown role.");
                    return null;
            }
        }
    }
}
