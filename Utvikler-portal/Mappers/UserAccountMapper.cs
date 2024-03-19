using Utvikler_portal.Mappers.Interface;
using Utvikler_portal.Models.DTOs;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Mappers;

public class UserAccountMapper : IMapper<UserAccount, UserAccountDTO>
{
    public UserAccountDTO MapToDTO(UserAccount model)
    {
        return new UserAccountDTO(
            model.Id,
            model.FirstName,
            model.LastName,
            model.Phone,
            model.Email,
            model.UserName,
            model.Created,
            model.Updated);
    }

    public UserAccount MapToModel(UserAccountDTO dto)
    {
        var dtNow = DateTime.Now;

        return new UserAccount()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Email = dto.Email,
            UserName = dto.UserName,
            Updated = dtNow
        };
    }
}
