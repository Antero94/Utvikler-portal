using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repositories.Interfaces;

public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllSkillsAsync(int pageNr, int pageSize, string sortBy);
    Task<Skill?> GetSkillByIdAsync(Guid id);
    Task<Skill> CreateSkillAsync(Skill skill);
    Task<Skill?> UpdateSkillAsync(Guid id, Skill skill);
    Task DeleteSkillAsync(Guid id);
}

