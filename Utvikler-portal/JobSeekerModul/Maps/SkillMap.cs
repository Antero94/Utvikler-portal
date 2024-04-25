using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Maps.Interfaces;

namespace Utvikler_portal.JobSeekerModul.Maps;

public class SkillMap : IMaps<Skill, SkillDTO>
{
    public SkillDTO MapToDTO(Skill model)
    {
        return new SkillDTO(

            model.Id,
            model.UserId,
            model.Name,
            model.Level
        );
    }

    public Skill MapToModel(SkillDTO dTO)
    {
        return new Skill
        {
            Id = dTO.Id,
            Name = dTO.Name,
            Level = dTO.Level,
            Created = DateTime.Now
        };
    }
}
