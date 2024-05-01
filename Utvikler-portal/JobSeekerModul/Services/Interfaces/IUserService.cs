using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.JobSeekerModul.Services.Interfaces;

public interface IUserService
{

    Task<ICollection<UserDTO>> GetAllUsersAsync(int pageNr, int pageSize, string sortBy);
    Task<UserDTO?> GetUserByIdAsync(Guid id);
    Task<UserDTO?> UpdateUserAsync(Guid id, UserDTO dTO);
    Task<UserDTO?> DeleteUserAsync(Guid id);
    Task<UserDTO?> CreateUserAsync(UserDTO dTO);

}

