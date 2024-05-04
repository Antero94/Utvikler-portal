using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.JobSeekerModul.Services.Interfaces;

public interface IEducationService
{
    Task<ICollection<EducationDTO>> GetAllEducationsAsync(int pageNr, int pageSize, string sortBy);
    Task<EducationDTO?> GetEducationByIdAsync(Guid id);
    Task<EducationDTO?> UpdateEducationAsync(Guid id, EducationDTO dTO);
    //Task<EducationDTO?> DeleteEducationAsync(Guid id);
    Task<EducationDTO?> CreateEducationAsync(EducationDTO dTO);
    Task DeleteEducationAsync(Guid id);
}

