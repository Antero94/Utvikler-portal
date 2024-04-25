namespace Utvikler_portal.Auth.DTO;

public record RegisterMemberResponse(
    Guid MemberId,
    string Username,
    string Email,
    string UserType,
    string Message);