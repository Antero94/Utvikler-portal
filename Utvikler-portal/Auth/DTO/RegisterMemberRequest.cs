namespace Utvikler_portal.Auth.DTO;

public record RegisterMemberRequest(
    string Name,
    string UserName,
    string Email,
    string Password,
    int UserType
    );