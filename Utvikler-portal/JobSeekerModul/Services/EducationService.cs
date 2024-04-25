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
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMaps<Education, EducationDTO> _educationMap;

        public EducationService(IMaps<Education, EducationDTO> educationMap, IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
            _educationMap = educationMap;
        }

        public async Task<ICollection<EducationDTO>> GetAllEducationsAsync(int pageNr, int pageSize, string sortBy)
        {
            var educations = await _educationRepository.GetAllEducationsAsync(pageNr, pageSize, sortBy);
            var dTO = educations.Select(_educationMap.MapToDTO).ToList();
            return dTO;
        }

        public async Task<EducationDTO?> GetEducationByIdAsync(Guid id)
        {
            var education = await _educationRepository.GetEducationByIdAsync(id);
            if (education == null)
                return null;
            return _educationMap.MapToDTO(education);
        }

        public async Task<EducationDTO?> CreateEducationAsync(EducationDTO dTO)
        {
            var education = _educationMap.MapToModel(dTO);
            education = await _educationRepository.CreateEducationAsync(education);
            return _educationMap.MapToDTO(education);
        }

        public async Task<EducationDTO?> UpdateEducationAsync(Guid id, EducationDTO dTO)
        {
            var existingEducation = await _educationRepository.GetEducationByIdAsync(id);
            if (existingEducation == null)
                return null;

            var updatedEducation = _educationMap.MapToModel(dTO);
            updatedEducation.Id = id;  // Ensure the ID remains unchanged
            updatedEducation = await _educationRepository.UpdateEducationAsync(id, updatedEducation);
            return _educationMap.MapToDTO(updatedEducation);
        }

        public async Task DeleteEducationAsync(Guid id)
        {
            await _educationRepository.DeleteEducationAsync(id);
        }
    }
}
