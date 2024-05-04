using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.JobSeekerModul.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;
    private readonly IMaps<Skill, SkillDTO> _skillMap;

    public SkillService(IMaps<Skill, SkillDTO> skillMap, ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
        _skillMap = skillMap;
    }

    public async Task<ICollection<SkillDTO>> GetAllSkillsAsync(int pageNr, int pageSize, string sortBy)
    {
        var skills = await _skillRepository.GetAllSkillsAsync(pageNr, pageSize, sortBy);
        var dTO = skills.Select(_skillMap.MapToDTO).ToList();
        return dTO;
    }

    public async Task<SkillDTO?> GetSkillByIdAsync(Guid id)
    {
        var skill = await _skillRepository.GetSkillByIdAsync(id);
        if (skill == null)
            return null;
        return _skillMap.MapToDTO(skill);
    }

    public async Task<SkillDTO?> CreateSkillAsync(SkillDTO dTO)
    {
        var skill = _skillMap.MapToModel(dTO);
        skill = await _skillRepository.CreateSkillAsync(skill);
        return _skillMap.MapToDTO(skill);
    }

    public async Task<SkillDTO?> UpdateSkillAsync(Guid id, SkillDTO dTO)
    {
        var existingSkill = await _skillRepository.GetSkillByIdAsync(id);
        if (existingSkill == null)
            return null;

        var updatedSkill = _skillMap.MapToModel(dTO);
        updatedSkill.Id = id;  // Ensure the ID remains unchanged
        var res = await _skillRepository.UpdateSkillAsync(id, updatedSkill);
        return res != null ? _skillMap.MapToDTO(updatedSkill) : null;
    }

    public async Task DeleteSkillAsync(Guid id)
    {
        await _skillRepository.DeleteSkillAsync(id);
    }
}
