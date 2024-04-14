using Microsoft.EntityFrameworkCore;
using Utvikler_portal.JobbModul.Models.Entities;
using Utvikler_portal.JobbModul.Repository.Interfaces;
using Utvikler_portal.Shared.Data;

namespace Utvikler_portal.JobbModul.Repository;

public class CompanyRepository : ICompanyRepository
{
    private readonly UtviklerPortalDbContext _dbContext;
    public CompanyRepository(UtviklerPortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CompanyAccount?> CreateCompanyAccountAsync(CompanyAccount companyAccount)
    {
        var company = await _dbContext.CompanyAccounts.AddAsync(companyAccount);
        await _dbContext.SaveChangesAsync();

        if (company == null) return null;
        return company.Entity;
    }

    public async Task<CompanyAccount?> DeleteAsync(Guid id)
    {
        var company = await _dbContext.CompanyAccounts.FirstOrDefaultAsync(x => x.Id == id);
        if (company == null) return null;

        var entity = _dbContext.CompanyAccounts.Remove(company);
        await _dbContext.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<ICollection<CompanyAccount>> GetAllCompaniesAsync(int pageNr, int pageSize)
    {
        return await _dbContext.CompanyAccounts
            .OrderBy(x => x.Id)
            .Skip(pageSize * (pageNr - 1))
            .Take(pageSize).ToListAsync();
    }

    public async Task<CompanyAccount?> GetCompanyByIdAsync(Guid id)
    {
        return await _dbContext.CompanyAccounts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CompanyAccount?> UpdateAsync(Guid id, CompanyAccount companyAccount)
    {
        await _dbContext.CompanyAccounts.Where(x => x.Id == id)
            .ExecuteUpdateAsync(setters => setters
            .SetProperty(x => x.Id, companyAccount.Id)
            .SetProperty(x => x.CompanyName, companyAccount.CompanyName)
            .SetProperty(x => x.CompanyPhone, companyAccount.CompanyPhone)
            .SetProperty(x => x.CompanyEmail, companyAccount.CompanyEmail)
            .SetProperty(x => x.Updated, DateTime.Now));
        await _dbContext.SaveChangesAsync();

        var company = await _dbContext.CompanyAccounts.FirstOrDefaultAsync(x => x.Id == id);
        if (company == null) return null;

        return company;
    }
}
