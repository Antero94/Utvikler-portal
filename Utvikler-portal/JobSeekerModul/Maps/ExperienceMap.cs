using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Maps.Interfaces;

namespace Utvikler_portal.JobSeekerModul.Maps;

public class ExperienceMap : IMaps<Experience, ExperienceDTO>
{
    public ExperienceDTO MapToDTO(Experience model)
    {
        return new ExperienceDTO(
            model.Id,
            model.UserId,
            model.CompanyName,
            model.Position,
            model.StartDate,
            model.EndDate
        );
    }

    public Experience MapToModel(ExperienceDTO dto)
    {
        return new Experience
        {
            Id = dto.Id,
            CompanyName = dto.CompanyName,
            Position = dto.Position,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Created = DateTime.Now  
        };
    }
}

