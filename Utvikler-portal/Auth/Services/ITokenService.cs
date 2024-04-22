using Utvikler_portal.Auth.ValueObjects;

namespace Utvikler_portal.Auth.Services;

public interface ITokenService
{
    string GenerateAccessToken(int Id, string name, string email, UserType type);
}