namespace Utvikler_portal.Models.DTOs;

public record UserAccountDTO(
    int Id,
    string FirstName,
    string LastName,
    string Phone,
    string Email,
    string UserName,
    DateTime Created,
    DateTime Updated);
