using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.JobSeekerModul.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMaps<Education, EducationDTO> _educationMap;

        public EducationService(IEducationRepository educationRepository, IMaps<Education, EducationDTO> educationMap)
        {
            _educationRepository = educationRepository;
            _educationMap = educationMap;
        }

        public async Task<EducationDTO> CreateEducationAsync(EducationDTO educationDto)
        {
            var education = _educationMap.MapToModel(educationDto);
            var createdEducation = await _educationRepository.AddAsync(education);
            return _educationMap.MapToDTO(createdEducation);
        }

        public async Task<EducationDTO> GetEducationByIdAsync(int id)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            if (education == null)
            {
                return null;
            }
            return _educationMap.MapToDTO(education);
        }

        public async Task<IEnumerable<EducationDTO>> GetAllEducationsAsync()
        {
            var educations = await _educationRepository.GetAllAsync();
            var educationDtos = new List<EducationDTO>();
            foreach (var education in educations)
            {
                educationDtos.Add(_educationMap.MapToDTO(education));
            }
            return educationDtos;
        }

        public async Task UpdateEducationAsync(EducationDTO educationDto)
        {
            var existingEducation = await _educationRepository.GetByIdAsync(educationDto.Id);
            if (existingEducation == null)
            {
                return;
            }
            existingEducation.Id = educationDto.Id;
            existingEducation.School = educationDto.School;
            existingEducation.Degree = educationDto.Degree;
            existingEducation.FieldOfStudy = educationDto.FieldOfStudy;
            existingEducation.GraduationDate = educationDto.GraduationDate;
            

            await _educationRepository.UpdateAsync(existingEducation);
        }

        public async Task DeleteEducationAsync(int id)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            if (education == null)
            {
                return;
            }
            await _educationRepository.DeleteAsync(id);
        }
    }
}
