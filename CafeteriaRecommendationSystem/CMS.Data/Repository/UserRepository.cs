using Common.Models;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class UserRepository : CrudBaseRepository<User>, IUserRepository
    {
        public UserRepository(CMSDbContext context) : base(context)
        {
        }

        public async Task<User> AuthenticateUser(UserLogin userLogin)
        {
            return await _context.Users.Where(u=>u.Id == userLogin.EmployeeId && u.Name == userLogin.Name).FirstOrDefaultAsync();
        }

    }

}
