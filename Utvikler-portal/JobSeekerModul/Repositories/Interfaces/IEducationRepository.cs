using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> GetAllEducationsAsync();
        Task<Education> GetEducationByIdAsync(int id);
        Task<Education> AddEducationAsync(Education education);
        Task<Education> UpdateEducationAsync(Education education);
        Task DeleteEducationAsync(int id);
    }

}

