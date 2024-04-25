using Microsoft.EntityFrameworkCore;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utvikler_portal.JobSeekerModul.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UtviklerPortalDbContext _dbContext;

        public UserRepository(UtviklerPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(int pageNr, int pageSize, string sortBy)
        {
            IQueryable<User> query = _dbContext.User;

 

            return await query.Skip(pageSize * (pageNr - 1)).Take(pageSize).ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserAsync(Guid id, User updatedUser)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.Educations = updatedUser.Educations;
                user.Skills = updatedUser.Skills;
                user.Experiences = updatedUser.Experiences;
                await _dbContext.SaveChangesAsync();
            }
            return user;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _dbContext.User.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
