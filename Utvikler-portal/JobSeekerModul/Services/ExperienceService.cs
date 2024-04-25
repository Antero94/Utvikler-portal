using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.JobSeekerModul.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMaps<Experience, ExperienceDTO> _experienceMap;

        public ExperienceService(IMaps<Experience, ExperienceDTO> experienceMap, IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
            _experienceMap = experienceMap;
        }

        public async Task<ICollection<ExperienceDTO>> GetAllExperiencesAsync(int pageNr, int pageSize, string sortBy)
        {
            var experiences = await _experienceRepository.GetAllExperiencesAsync(pageNr, pageSize, sortBy);
            var dTO = experiences.Select(_experienceMap.MapToDTO).ToList();
            return dTO;
        }

        public async Task<ExperienceDTO?> GetExperienceByIdAsync(Guid id)
        {
            var experience = await _experienceRepository.GetExperienceByIdAsync(id);
            if (experience == null)
                return null;
            return _experienceMap.MapToDTO(experience);
        }

        public async Task<ExperienceDTO?> CreateExperienceAsync(ExperienceDTO dTO)
        {
            var experience = _experienceMap.MapToModel(dTO);
            experience = await _experienceRepository.CreateExperienceAsync(experience);
            return _experienceMap.MapToDTO(experience);
        }

        public async Task<ExperienceDTO?> UpdateExperienceAsync(Guid id, ExperienceDTO dTO)
        {
            var existingExperience = await _experienceRepository.GetExperienceByIdAsync(id);
            if (existingExperience == null)
                return null;

            var updatedExperience = _experienceMap.MapToModel(dTO);
            updatedExperience.Id = id;  // Ensure the ID remains unchanged
            updatedExperience = await _experienceRepository.UpdateExperienceAsync(id, updatedExperience);
            return _experienceMap.MapToDTO(updatedExperience);
        }

        public async Task DeleteExperienceAsync(Guid id)
        {
            await _experienceRepository.DeleteExperienceAsync(id);
        }
    }
}
