using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.Auth.Models;

namespace Utvikler_portal.Auth.Services;

public class EncryptionService:IEncryptionService
{
    public HashedPassword EncryptPassword(string password)
    {
        int workFactor = 10;
        string salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password,salt);
        return new HashedPassword(salt,hashedPassword);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
    
    
}