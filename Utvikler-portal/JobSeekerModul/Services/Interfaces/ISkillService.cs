using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.JobSeekerModul.Services.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync(int id);
        Task UpdateSkillAsync(int id);
        Task DeleteSkillAsync(int id);
        Task<Education> CreateSkillAsync(SkillDTO skillDto);
    }
}

