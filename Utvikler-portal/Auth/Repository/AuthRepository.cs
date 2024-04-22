using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Utvikler_portal.Auth.ValueObjects;
using Utvikler_portal.Shared.Data;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Auth.Repository;

public class AuthRepository:IAuthRepository
{
    private readonly UtviklerPortalDbContext _ctx;

    public AuthRepository(UtviklerPortalDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Member?> GetMemberByEmail(Email email)
    {
        return await _ctx.Members.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Member> AddMember(Member member)
    {
        EntityEntry<Member> addedmember = await _ctx.AddAsync(member);
        await _ctx.SaveChangesAsync();
        return addedmember.Entity;
    }

    public async Task DeleteMemberById(Member member)
    {
        _ctx.Members.Remove(member);
        await _ctx.SaveChangesAsync();
    }
}