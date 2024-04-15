namespace Utvikler_portal.Auth.DTO;

public record LoginUserResponse(
    string AccessToken,
    string UserType,
    string Message);