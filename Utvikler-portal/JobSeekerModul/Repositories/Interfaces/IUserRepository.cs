using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repositories.Interfaces
{
	public interface IUserRepository
	{
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(int id);

        Task<IEnumerable<User>> FindUserAsync(Expression<Func<User, bool>> predicate);

    }
}

