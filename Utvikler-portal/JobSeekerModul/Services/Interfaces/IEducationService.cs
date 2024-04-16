using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.JobSeekerModul.Services.Interfaces
{
	public interface IEducationService
	{
        Task<IEnumerable<Education>> GetAllEducationsAsync();
        Task<Education> GetEducationByIdAsync(int id);
        Task UpdateEducationAsync(int id);
        Task DeleteEducationAsync(int id);
        Task<Education> CreateEducationAsync(EducationDTO educationDto);
    }
}

