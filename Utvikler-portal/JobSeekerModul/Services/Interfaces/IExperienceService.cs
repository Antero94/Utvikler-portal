using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.JobSeekerModul.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<IEnumerable<Experience>> GetAllExperiencesAsync();
        Task<Experience> GetExperienceByIdAsync(int id);
        Task UpdateExperienceAsync(int id);
        Task DeleteExperienceAsync(int id);
        Task<Education> CreateExperienceAsync(ExperienceDTO experienceDto);
    }
}

