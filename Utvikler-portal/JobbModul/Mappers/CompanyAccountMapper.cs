using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;

namespace Utvikler_portal.JobbModul.Mappers;

public class CompanyAccountMapper : IMapper<CompanyAccount, CompanyAccountDTO>
{
    public CompanyAccountDTO MapToDTO(CompanyAccount model)
    {
        return new CompanyAccountDTO(
            model.Id,
            model.CompanyName,
            model.CompanyPhone,
            model.CompanyEmail,
            model.Created.ToLocalTime(),
            model.Updated.ToLocalTime());
    }

    public CompanyAccount MapToModel(CompanyAccountDTO dto)
    {
        var dtNow = DateTime.UtcNow;

        return new CompanyAccount()
        {
            Id = dto.Id,
            CompanyName = dto.CompanyName,
            CompanyPhone = dto.CompanyPhone,
            CompanyEmail = dto.CompanyEmail,
            Updated = dtNow
        };
    }
}
