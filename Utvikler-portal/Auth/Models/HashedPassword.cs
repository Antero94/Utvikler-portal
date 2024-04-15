namespace Utvikler_portal.Auth.Models;

public record HashedPassword(
    string Hash,
    string Salt);