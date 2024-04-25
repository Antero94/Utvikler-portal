using Utvikler_portal.Auth.ValueObjects;

namespace Utvikler_portal.Auth.Services;

public interface ITokenService
{
    string GenerateAccessToken(Guid Id, string name, string email, UserType type);
}