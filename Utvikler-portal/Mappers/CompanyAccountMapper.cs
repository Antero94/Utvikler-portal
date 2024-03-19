using Utvikler_portal.Mappers.Interface;
using Utvikler_portal.Models.DTOs;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Mappers;

public class CompanyAccountMapper : IMapper<CompanyAccount, CompanyAccountDTO>
{
    public CompanyAccountDTO MapToDTO(CompanyAccount model)
    {
        return new CompanyAccountDTO(
            model.Id, 
            model.CompanyName, 
            model.CompanyPhone, 
            model.CompanyEmail, 
            model.UserName,
            model.Created,
            model.Updated);
    }

    public CompanyAccount MapToModel(CompanyAccountDTO dto)
    {
        var dtNow = DateTime.Now;

        return new CompanyAccount()
        {
            Id = dto.Id,
            CompanyName = dto.CompanyName,
            CompanyPhone = dto.CompanyPhone,
            CompanyEmail = dto.CompanyEmail,
            UserName = dto.UserName,
            Updated = dtNow
        };
    }
}
