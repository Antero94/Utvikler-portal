using Utvikler_portal.Auth.Models;

namespace Utvikler_portal.Auth.Services;

public interface IEncryptionService
{
    HashedPassword EncryptPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
}