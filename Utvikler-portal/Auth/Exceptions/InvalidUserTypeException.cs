namespace Utvikler_portal.Auth.Exceptions;

public class InvalidUserTypeException:Exception
{
    public InvalidUserTypeException(int type) 
        : base($"User type {type} is invalid")
    {
    }
}