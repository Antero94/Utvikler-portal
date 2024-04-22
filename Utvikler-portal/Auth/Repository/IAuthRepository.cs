using Utvikler_portal.Auth.ValueObjects;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Auth.Repository;

public interface IAuthRepository
{
    Task<Member?> GetMemberByEmail(Email email);
    Task<Member> AddMember(Member member);
    Task DeleteMemberById(Member member);
}