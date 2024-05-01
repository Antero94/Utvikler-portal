namespace Utvikler_portal.JobSeekerModul.Models.DTOs;

public record EducationDTO(
    Guid Id,
    Guid UserId,
    string School,
    string Degree,
    string FieldOfStudy,
    DateTime GraduationDate);
