namespace Utvikler_portal.Auth.DTO;

public record RegisterMemberResponse(
    int MemberId,
    string Username,
    string Email,
    string UserType,
    string Message);