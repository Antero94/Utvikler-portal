namespace Utvikler_portal.Models.DTOs;

public record JobPostDTO(
    int Id,
    int CompanyAccountId,
    string Employer,
    string Position,
    string JuniorOrSenior,
    string EmploymentType,
    string Location,
    DateTime Deadline,
    string Title,
    string Description,
    string Tags,
    string ContactOne,
    string ContactTwo,
    string ContactOnePhone,
    string ContactTwoPhone,
    DateTime Created,
    DateTime Updated);
