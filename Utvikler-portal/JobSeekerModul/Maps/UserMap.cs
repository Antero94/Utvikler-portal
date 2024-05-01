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

    public User MapToModel(UserDTO dTO)
    {
        var dtNow = DateTime.Now;

        return new User()
        {
            Id = dTO.Id,
            FirstName = dTO.FirstName,
            LastName = dTO.LastName,
            Email = dTO.Email,
            Updated = dtNow
        };
    }
}
