using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.JobSeekerModul.Services.Interfaces;

public interface IExperienceService
{
    Task<ICollection<ExperienceDTO>> GetAllExperiencesAsync(int pageNr, int pageSize, string sortBy);
    Task<ExperienceDTO?> GetExperienceByIdAsync(Guid id);
    Task<ExperienceDTO?> UpdateExperienceAsync(Guid id, ExperienceDTO dTO);
    //Task<ExperienceDTO?> DeleteExperienceAsync(Guid id);
    Task<ExperienceDTO?> CreateExperienceAsync(ExperienceDTO dTO);
    Task DeleteExperienceAsync(Guid id);
}

