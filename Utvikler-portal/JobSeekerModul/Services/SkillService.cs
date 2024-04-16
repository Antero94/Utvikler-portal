using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;


namespace Utvikler_portal.JobSeekerModul.Services
{
	public class SkillService : ISkillService
	{
        private readonly ISkillRepository _skillRepository;
        private readonly IMaps<Skill, SkillDTO> _skillMap;

        public SkillService(ISkillRepository skillRepository, IMaps<Skill, SkillDTO> skillMap)
        {
            _skillRepository = skillRepository;
            _skillMap = skillMap;
        }

        public async Task<SkillDTO> CreateSkillAsync(SkillDTO skillDto)
        {
            var skill = _skillMap.MapToModel(skillDto);
            var createdSkill = await _skillRepository.AddAsync(skill);
            return _skillMap.MapToDTO(createdSkill);
        }

        public async Task<SkillDTO> GetSkillByIdAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                return null;
            }
            return _skillMap.MapToDTO(skill);
        }

        public async Task<IEnumerable<SkillDTO>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.GetAllAsync();
            var skillDtos = new List<SkillDTO>();
            foreach (var skill in skills)
            {
                skillDtos.Add(_skillMap.MapToDTO(skill));
            }
            return skillDtos;
        }

        public async Task UpdateSkillAsync(SkillDTO skillDto)
        {
            var existingSkill = await _skillRepository.GetByIdAsync(skillDto.Id);
            if (existingSkill == null)
            {
                return;
            }
            existingSkill.Id = skillDto.Id;
            existingSkill.Name = skillDto.Name;
            existingSkill.Level = skillDto.Level;

            await _skillRepository.UpdateAsync(existingSkill);
        }

        public async Task DeleteSkillAsync(int id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                return;
            }
            await _skillRepository.DeleteAsync(id);
        }
    }
}


