using Utvikler_portal.JobbModul.Models.DTOs;

namespace Utvikler_portal.JobbModul.Services.Interfaces;

public interface ICompanyService
{
    Task<ICollection<CompanyAccountDTO>> GetAllCompaniesAsync(int pageNr, int pageSize);
    Task<CompanyAccountDTO?> CreateCompanyAccountAsync(CompanyRegistrationDTO dto, Guid userId);
    Task<CompanyAccountDTO?> UpdateAsync(Guid userId, CompanyAccountDTO dto);
    Task<CompanyAccountDTO?> DeleteAsync(Guid userId);
    Task<CompanyAccountDTO?> GetCompanyByIdAsync(Guid userId);
}
