using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.JobSeekerModul.Services.Interfaces
{
	public interface IUserService
	{
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task UpdateUserAsync(int id);
        Task DeleteUserAsync(int id);
        Task<User> CreateUserAsync(UserRegDTO userDto);
        Task AddUserAsync(UserDTO userDto);
    }
}

