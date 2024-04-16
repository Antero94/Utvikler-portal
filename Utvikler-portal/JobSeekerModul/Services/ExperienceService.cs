using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.JobSeekerModul.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMaps<Experience, ExperienceDTO> _experienceMap;

        public ExperienceService(IExperienceRepository experienceRepository, IMaps<Experience, ExperienceDTO> experienceMap)
        {
            _experienceRepository = experienceRepository;
            _experienceMap = experienceMap;
        }

        public async Task<ExperienceDTO> CreateExperienceAsync(ExperienceDTO experienceDto)
        {
            var experience = _experienceMap.MapToModel(experienceDto);
            var createdExperience = await _experienceRepository.AddAsync(experience);
            return _experienceMap.MapToDTO(createdExperience);
        }

        public async Task<ExperienceDTO> GetExperienceByIdAsync(int id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            if (experience == null)
            {
                return null;
            }
            return _experienceMap.MapToDTO(experience);
        }

        public async Task<IEnumerable<ExperienceDTO>> GetAllExperiencesAsync()
        {
            var experiences = await _experienceRepository.GetAllAsync();
            var experienceDtos = new List<ExperienceDTO>();
            foreach (var experience in experiences)
            {
                experienceDtos.Add(_experienceMap.MapToDTO(experience));
            }
            return experienceDtos;
        }

        public async Task UpdateExperienceAsync(ExperienceDTO experienceDto)
        {
            var existingExperience = await _experienceRepository.GetByIdAsync(experienceDto.Id);
            if (existingExperience == null)
            {
                return;
            }
            existingExperience.Id = experienceDto.Id;
            existingExperience.CompanyName = experienceDto.CompanyName;
            existingExperience.StartDate = experienceDto.StartDate;
            existingExperience.EndDate = experienceDto.EndDate;

            await _experienceRepository.UpdateAsync(existingExperience);
        }

        public async Task DeleteExperienceAsync(int id)
        {
            var experience = await _experienceRepository.GetByIdAsync(id);
            if (experience == null)
            {
                return;
            }
            await _experienceRepository.DeleteAsync(id);
        }
    }
}
