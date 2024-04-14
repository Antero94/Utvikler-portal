using Microsoft.EntityFrameworkCore;
using Utvikler_portal.JobbModul.Models.Entities;

namespace Utvikler_portal.Shared.Data;

public class UtviklerPortalDbContext(DbContextOptions<UtviklerPortalDbContext> options) : DbContext(options)
{
    public DbSet<CompanyAccount> CompanyAccounts { get; set; }
    public DbSet<JobPost> JobPosts { get; set; }
}
