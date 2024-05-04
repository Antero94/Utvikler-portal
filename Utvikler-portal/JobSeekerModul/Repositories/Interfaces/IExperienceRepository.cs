using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repositories.Interfaces;

public interface IExperienceRepository
{
    Task<IEnumerable<Experience>> GetAllExperiencesAsync(int pageNr, int pageSize, string sortBy);
    Task<Experience?> GetExperienceByIdAsync(Guid id);
    Task<Experience> CreateExperienceAsync(Experience experience);
    Task<Experience?> UpdateExperienceAsync(Guid id, Experience experience);
    Task DeleteExperienceAsync(Guid id);

}

