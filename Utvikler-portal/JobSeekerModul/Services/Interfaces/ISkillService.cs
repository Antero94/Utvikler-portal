using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.JobSeekerModul.Services.Interfaces;

public interface ISkillService
{
    Task<ICollection<SkillDTO>> GetAllSkillsAsync(int pageNr, int pageSize, string sortBy);
    Task<SkillDTO?> GetSkillByIdAsync(Guid id);
    Task<SkillDTO?> UpdateSkillAsync(Guid id, SkillDTO dTO);
    //Task<SkillDTO?> DeleteSkillAsync(Guid id);
    Task<SkillDTO?> CreateSkillAsync(SkillDTO dTO);
    Task DeleteSkillAsync(Guid id);
}

