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
            int.TryParse(userLogin.EmployeeId, out int id);
            return await _context.User.Where(u=>u.Id == id && u.Name.ToLower() == userLogin.Name.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<bool> HasVotedToday(int userId)
        {
            return await _context.User.AnyAsync(u => u.Id == userId && u.HasVotedToday);
        }

        public async Task SetUserVoting(bool status)
        {
            var users = await _context.User.ToListAsync(); 

            foreach (var user in users)
            {
                user.HasVotedToday = false;
            }

            _context.UpdateRange(users);
            await _context.SaveChangesAsync();
        }

    }

}
