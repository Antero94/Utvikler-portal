using Utvikler_portal.JobbModul.Models.Entities;

namespace Utvikler_portal.JobbModul.Repository.Interfaces;

public interface ICompanyRepository
{
    Task<ICollection<CompanyAccount>> GetAllCompaniesAsync(int pageNr, int pageSize);
    Task<CompanyAccount?> CreateCompanyAccountAsync(CompanyAccount companyAccount);
    Task<CompanyAccount?> UpdateAsync(Guid id, CompanyAccount companyAccount);
    Task<CompanyAccount?> DeleteAsync(Guid id);
    Task<CompanyAccount?> GetCompanyByIdAsync(Guid id);
}
