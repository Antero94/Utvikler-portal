namespace Utvikler_portal.Auth.DTO;

public record LoginUserRequest(
    string Email,
    string Password);