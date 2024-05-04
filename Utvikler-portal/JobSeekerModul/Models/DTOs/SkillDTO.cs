namespace Utvikler_portal.JobSeekerModul.Models.DTOs;

public record SkillDTO(
    Guid Id,
    Guid UserId,
    string Name,
    string Level);
