using Utvikler_portal.Mappers.Interface;
using Utvikler_portal.Models.DTOs;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Mappers;

public class UserRegistrationMapper : IMapper<UserAccount, UserRegistrationDTO>
{
    public UserRegistrationDTO MapToDTO(UserAccount model)
    {
        throw new NotImplementedException();
    }

    public UserAccount MapToModel(UserRegistrationDTO dto)
    {
        var dtNow = DateTime.Now;

        return new UserAccount()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Email = dto.Email,
            UserName = dto.UserName,
            IsAdmin = false,
            Created = dtNow,
            Updated = dtNow
        };
    }
}
