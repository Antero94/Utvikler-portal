using Microsoft.EntityFrameworkCore;
using Utvikler_portal.Auth.ValueObjects;
using Utvikler_portal.JobbModul.Models.Entities;
using Utvikler_portal.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.Shared.Data;

public class UtviklerPortalDbContext : DbContext
{
    public UtviklerPortalDbContext(DbContextOptions<UtviklerPortalDbContext> options) : base(options)
    {
    }


    public DbSet<User> User { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<CompanyAccount> CompanyAccounts { get; set; }
    public DbSet<JobPost> JobPosts { get; set; }
    public DbSet<Member> Members { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<Member>().HasKey(x => x.MemberId);
        modelBuilder.Entity<Member>().Property(x => x.Email)
            .HasConversion(x => x.value, value => Email.Create(value))
            .IsRequired();

        Dictionary<int, string> _userTypes = new()
        {
            {1,"jobseeker"},
            {2,"companyuser"}
        };
        modelBuilder.Entity<Member>().Property(x => x.UserType)
            .HasConversion(x => x.Value, Value => UserType.Create(
                _userTypes.FirstOrDefault(x => x.Value == Value).Key));

    }
}
