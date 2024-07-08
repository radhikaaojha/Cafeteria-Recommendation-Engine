using CMS.Common.Models;
using CMS.Data.Entities;
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

        public async Task<User> AuthenticateUser(LoginRequest userLogin)
        {
            int.TryParse(userLogin.EmployeeId, out int id);
            return await _context.User.Where(u=>u.Id == id && u.Name.ToLower() == userLogin.Name.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<bool> HasVotedToday(int userId)
        {
            return await _context.User.AnyAsync(u => u.Id == userId && u.HasVotedToday);
        }

        public async Task SetUsersVotingStatus(bool status)
        {
            var users = await _context.User.ToListAsync(); 

            foreach (var user in users)
            {
                user.HasVotedToday = false;
            }

            _context.UpdateRange(users);
            await _context.SaveChangesAsync();
        }

        public async Task SetVotingStatusForAUser(bool status, int userId)
        {
            var user = _context.User.FirstOrDefault(u=>u.Id ==userId);   
            user.HasVotedToday = status;
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task SubmitUserPreferences(List<UserPreferences> userPreferences)
        {
            var userId = userPreferences.FirstOrDefault()?.UserId; 
            if (userId != null)
            {
                var existingPreferences = await _context.UserPreference
                    .Where(up => up.UserId == userId)
                    .ToListAsync();

                var preferences = userPreferences.Select(up => new UserPreference
                {
                    UserId = up.UserId,
                    CharacteristicId = (int)up.CharacteristicId,
                    Priority = up.Priority
                }).ToList();

                if (existingPreferences.Any())
                {
                    foreach (var preference in preferences)
                    {
                        var existingPreference = existingPreferences.FirstOrDefault(ep => ep.CharacteristicId == preference.CharacteristicId);
                        if (existingPreference != null)
                        {
                            existingPreference.Priority = preference.Priority;
                            _context.UserPreference.Update(existingPreference);
                        }
                        else
                        {
                            _context.UserPreference.Add(preference);
                        }
                    }
                }
                else
                {
                    await _context.UserPreference.AddRangeAsync(preferences);
                }
                await _context.SaveChangesAsync();
            }

        }
    }

}
