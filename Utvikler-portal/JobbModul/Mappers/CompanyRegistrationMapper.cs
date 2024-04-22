using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;

namespace Utvikler_portal.JobbModul.Mappers;

public class CompanyRegistrationMapper : IMapper<CompanyAccount, CompanyRegistrationDTO>
{
    public CompanyRegistrationDTO MapToDTO(CompanyAccount model)
    {
        throw new NotImplementedException();
    }

    public CompanyAccount MapToModel(CompanyRegistrationDTO dto)
    {
        var dtNow = DateTime.UtcNow;

        return new CompanyAccount()
        {
            CompanyName = dto.CompanyName,
            CompanyPhone = dto.CompanyPhone,
            CompanyEmail = dto.CompanyEmail,
            Created = dtNow,
            Updated = dtNow
        };
    }
}
