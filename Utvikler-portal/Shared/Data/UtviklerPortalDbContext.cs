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

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var userIdOne = Guid.NewGuid();
        var userIdTwo = Guid.NewGuid();
        var companyIdOne = Guid.NewGuid();
        var companyIdTwo = Guid.NewGuid();

        modelBuilder.Entity<User>().HasData(
            new User { Id = userIdOne, FirstName = "Jhon", LastName = "Doe", Email = "john@mail.com", Created = DateTime.Now, Updated = DateTime.Now },
            new User { Id = userIdTwo, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Created = DateTime.Now, Updated = DateTime.Now }
        );

        modelBuilder.Entity<Education>().HasData(
            new Education { Id = Guid.NewGuid(), UserId = userIdOne, School = "Tech University", Degree = "BSc Computer Science", FieldOfStudy = "Computer Science", GraduationDate = new DateTime(2020, 6, 1) },
            new Education { Id = Guid.NewGuid(), UserId = userIdTwo, School = "Business School", Degree = "MBA", FieldOfStudy = "Business Administration", GraduationDate = new DateTime(2021, 6, 1) }
        );

        modelBuilder.Entity<Experience>().HasData(
            new Experience { Id = Guid.NewGuid(), UserId = userIdOne, CompanyName = "Tech Corp", Position = "Software Developer", StartDate = new DateTime(2018, 1, 1), EndDate = DateTime.Now, Created = DateTime.Now },
            new Experience { Id = Guid.NewGuid(), UserId = userIdTwo, CompanyName = "Business Inc.", Position = "Project Manager", StartDate = new DateTime(2019, 1, 1), EndDate = DateTime.Now, Created = DateTime.Now }
        );

        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = Guid.NewGuid(), UserId = userIdOne, Name = "C#", Level = "Intermediate", Created = DateTime.Now },
            new Skill { Id = Guid.NewGuid(), UserId = userIdTwo, Name = "Management", Level = "Advanced", Created = DateTime.Now }
        );

        modelBuilder.Entity<CompanyAccount>().HasData(
            new CompanyAccount { Id = companyIdOne, CompanyName = "Dev Solutions", CompanyEmail = "contact@techinnovators.com", CompanyPhone = "1234567890", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
            new CompanyAccount { Id = companyIdTwo, CompanyName = "Innovatech", CompanyEmail = "info@innovatech.com", CompanyPhone = "1234567890", Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
        );

        modelBuilder.Entity<JobPost>().HasData(
            new JobPost { Id = Guid.NewGuid(), CompanyAccountId = companyIdOne, Employer = "Innovatech", Position = "Senior Developer", JuniorOrSenior = "Senior", EmploymentType = "Full-time", Location = "Remote", Deadline = DateTime.UtcNow.AddDays(30), Title = "Senior Full-Stack Developer", Description = "We are looking for a senior full-stack developer to join our team.", Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
            new JobPost { Id = Guid.NewGuid(), CompanyAccountId = companyIdTwo, Employer = "DevSolutions", Position = "Front-end Developer", JuniorOrSenior = "Junior", EmploymentType = "Part-time", Location = "On-site", Deadline = DateTime.UtcNow.AddDays(30), Title = "Junior Front-end Developer", Description = "We are looking for a senior full-stack developer to join our team.", Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
        );

        modelBuilder.Entity<Member>().HasData(
            Member.Create("John Doe", "john.doe", Email.Create("johndoe@example.com"), "hashedpassword", "salt", UserType.Create(1)),
            Member.Create("Jane Smith", "jane.smith", Email.Create("janesmith@example.com"), "hashedpassword2", "salt2", UserType.Create(2))
        );
    }
}