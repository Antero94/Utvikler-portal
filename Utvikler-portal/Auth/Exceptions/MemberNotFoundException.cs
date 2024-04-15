namespace Utvikler_portal.Auth.Exceptions;

public class MemberNotFoundException:Exception
{
    public MemberNotFoundException(string? email) 
        : base($"Member with given email {email} is not found")
    {
    }
}