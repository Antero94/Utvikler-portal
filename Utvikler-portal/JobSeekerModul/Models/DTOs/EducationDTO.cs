namespace Utvikler_portal.JobSeekerModul.Models.DTOs;

public record EducationDTO(
    Guid Id,
    string School,
    string Degree,
    string FieldsOfStudy,
    DateTime GraduationDate


    );