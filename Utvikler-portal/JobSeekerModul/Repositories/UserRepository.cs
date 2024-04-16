using Utvikler_portal.JobSeekerModul.Data;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Utvikler_portal.JobSeekerModul.Repository
{
    public class UserRepository : IUserRepository
	{
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.User.ToListAsync();

        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> FindUserAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.User.Where(predicate).ToListAsync();
        }

        Task<User> IUserRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

