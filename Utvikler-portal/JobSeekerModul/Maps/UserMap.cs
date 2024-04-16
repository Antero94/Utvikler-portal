using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Maps;


public class UserMap : IMaps<User, UserDTO>
{
    public UserDTO MapToDTO(User model)
    {
        return new UserDTO(
            model.Id,
            model.FirstName,
            model.LastName,
            model.Email,
            model.Created,
            model.Updated);
    }

    public User MapToModel(UserDTO dto)
    {
        var dtNow = DateTime.Now;

        return new User()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Updated = dtNow
        };
    }
}
