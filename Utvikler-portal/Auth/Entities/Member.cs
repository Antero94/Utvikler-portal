using Utvikler_portal.Auth.ValueObjects;

namespace Utvikler_portal.Models.Entities;

public class Member
{
    private Member(Guid memberId,string name, string userName, Email email, string hash, string salt, UserType userType)
    {
        MemberId = memberId;
        Name = name;
        UserName = userName;
        Email = email;
        Hash = hash;
        Salt = salt;
        UserType = userType;
    }

    
    public Guid MemberId { get; private set; }
    public string Name { get; private set; }
    public string UserName { get; private set; }
    public Email Email { get; private set; }
    public string Hash { get; private set; }
    public string Salt { get; private set; }
    public UserType UserType { get; private set; }


    public static Member Create(string name, string userName, Email email, string hash, string salt, UserType userType)
    {
        return new Member(Guid.NewGuid(),name, userName, email, hash, salt, userType);
    }
}