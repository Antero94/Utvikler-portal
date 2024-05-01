using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Maps.Interfaces;

namespace Utvikler_portal.JobSeekerModul.Maps;

public class EducationMap : IMaps<Education, EducationDTO>
{
    public EducationDTO MapToDTO(Education model)
    {
        return new EducationDTO(
            model.Id,
            model.UserId,
            model.School,
            model.Degree,
            model.FieldOfStudy, 
            model.GraduationDate
        );
    }

    public Education MapToModel(EducationDTO dto)
    {
        return new Education
        {
            Id = dto.Id,
            School = dto.School,
            Degree = dto.Degree,
            FieldOfStudy = dto.FieldOfStudy, 
            GraduationDate = dto.GraduationDate
        };
    }
}
