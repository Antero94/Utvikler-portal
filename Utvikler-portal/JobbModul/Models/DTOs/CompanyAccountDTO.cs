namespace Utvikler_portal.JobbModul.Models.DTOs;

public record CompanyAccountDTO(
    Guid Id,
    string CompanyName,
    string CompanyPhone,
    string CompanyEmail,
    DateTime Created,
    DateTime Updated);
