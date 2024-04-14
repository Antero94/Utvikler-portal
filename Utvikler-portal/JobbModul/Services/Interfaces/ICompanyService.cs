using Utvikler_portal.JobbModul.Models.DTOs;

namespace Utvikler_portal.JobbModul.Services.Interfaces;

public interface ICompanyService
{
    Task<ICollection<CompanyAccountDTO>> GetAllCompaniesAsync(int pageNr, int pageSize);
    Task<CompanyAccountDTO?> CreateCompanyAccountAsync(CompanyRegistrationDTO dto);
    Task<CompanyAccountDTO?> UpdateAsync(Guid id, CompanyAccountDTO dto);
    Task<CompanyAccountDTO?> DeleteAsync(Guid id);
    Task<CompanyAccountDTO?> GetCompanyByIdAsync(Guid id);
}
