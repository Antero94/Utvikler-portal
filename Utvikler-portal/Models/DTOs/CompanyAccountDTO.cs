namespace Utvikler_portal.Models.DTOs;

public record CompanyAccountDTO(
    int Id,
    string CompanyName,
    string CompanyPhone,
    string CompanyEmail,
    string UserName,
    DateTime Created,
    DateTime Updated);
