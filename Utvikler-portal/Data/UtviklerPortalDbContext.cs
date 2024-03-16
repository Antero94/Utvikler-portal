using Microsoft.EntityFrameworkCore;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Data;

public class UtviklerPortalDbContext(DbContextOptions<UtviklerPortalDbContext> options) : DbContext(options)
{
    DbSet<CompanyAccount> CompanyAccounts { get; set; }
    DbSet<UserAccount> UserAccounts { get; set; }
    DbSet<JobPost> JobPosts { get; set; }
}
