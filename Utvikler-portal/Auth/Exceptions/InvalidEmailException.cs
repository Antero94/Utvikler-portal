namespace Utvikler_portal.Auth.Exceptions;

public class InvalidEmailException:Exception
{
    public InvalidEmailException(string? message) : base(message)
    {
    }
}