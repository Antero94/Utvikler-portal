using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(int pageNr, int pageSize, string sortBy);
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(Guid id, User user);
        Task DeleteUserAsync(Guid id);

    }

}

