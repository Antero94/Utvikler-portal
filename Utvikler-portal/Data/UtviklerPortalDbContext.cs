using Microsoft.EntityFrameworkCore;
using Utvikler_portal.Auth.ValueObjects;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Data;

public class UtviklerPortalDbContext: DbContext
{
    DbSet<CompanyAccount> CompanyAccounts { get; set; }
    DbSet<UserAccount> UserAccounts { get; set; }
    DbSet<JobPost> JobPosts { get; set; }
    public DbSet<Member>Members { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<Member>().HasKey(x => x.MemberId);
        modelBuilder.Entity<Member>().Property(x => x.Email)
            .HasConversion(x => x.value, value => Email.Create(value))
            .IsRequired();
        
        Dictionary<int,string> _userTypes = new ()
        {
            {1,"jobseeker"},
            {2,"companyuser"}
        };
        modelBuilder.Entity<Member>().Property(x=>x.UserType)
            .HasConversion(x=>x.Value,Value=>UserType.Create(
                _userTypes.FirstOrDefault(x=>x.Value==Value).Key));

    }
}
