using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Maps.Interfaces;

public interface IUserMaps
{
    User MapToModel(UserDTO dto);
    UserDTO MapToDTO(User entity);
}