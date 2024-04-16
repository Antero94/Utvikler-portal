namespace Utvikler_portal.JobSeekerModul.Models.DTOs;

public record UserDTO(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    DateTime Created,
    DateTime Updated
    );