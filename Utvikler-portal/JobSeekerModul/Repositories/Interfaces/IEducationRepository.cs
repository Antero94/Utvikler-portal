using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repositories.Interfaces;

public interface IEducationRepository
{
    Task<IEnumerable<Education>> GetAllEducationsAsync(int pageNr, int pageSize, string sortBy);
    Task<Education?> GetEducationByIdAsync(Guid id);
    Task<Education> CreateEducationAsync(Education education);
    Task<Education?> UpdateEducationAsync(Guid id, Education education);
    Task DeleteEducationAsync(Guid id);
    
}

