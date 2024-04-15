using Utvikler_portal.Auth.DTO;

namespace Utvikler_portal.Auth.Services;

public interface IMemberService
{
    Task<RegisterMemberResponse> RegisterMember(RegisterMemberRequest request);
    Task<LoginUserResponse> Login(LoginUserRequest request);
}