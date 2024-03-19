using Utvikler_portal.Mappers.Interface;
using Utvikler_portal.Models.DTOs;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Mappers;

public class CompanyRegistrationMapper : IMapper<CompanyAccount, CompanyRegistrationDTO>
{
    public CompanyRegistrationDTO MapToDTO(CompanyAccount model)
    {
        throw new NotImplementedException();
    }

    public CompanyAccount MapToModel(CompanyRegistrationDTO dto)
    {
        var dtNow = DateTime.Now;

        return new CompanyAccount()
        {
            CompanyName = dto.CompanyName,
            CompanyPhone = dto.CompanyPhone,
            CompanyEmail = dto.CompanyEmail,
            UserName = dto.UserName,
            Created = dtNow,
            Updated = dtNow
        };
    }
}
