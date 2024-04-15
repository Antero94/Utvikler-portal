using Utvikler_portal.Auth.Exceptions;

namespace Utvikler_portal.Auth.ValueObjects;

public class UserType
{
    private UserType(string value)
    {
        Value = value;
    }

    private static readonly Dictionary<int,string> _userTypes = new ()
    {
        {1,"jobseeker"},
        {2,"companyuser"}
    };
    public string Value { get; set; }


    public static UserType Create(int type)
    {
        if (!_userTypes.ContainsKey(type))
        {
            throw new InvalidUserTypeException(type);
        }

        return new UserType(_userTypes.First(x=>x.Key==type).Value);
    }
    
}