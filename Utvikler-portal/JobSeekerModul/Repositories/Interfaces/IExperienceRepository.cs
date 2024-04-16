using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repositories.Interfaces
{
	public interface IExperienceRepository
	{
        Task<IEnumerable<Experience>> GetAllExperiencesAsync();
        Task<Experience> GetExperienceByIdAsync(int id);
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<Experience> UpdateExperienceAsync(Experience experience);
        Task DeleteExperienceAsync(int id);
    }
}

