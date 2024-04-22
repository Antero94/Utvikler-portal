using Microsoft.EntityFrameworkCore;
using Utvikler_portal.JobbModul.Models.Entities;

namespace Utvikler_portal.Shared.Data;

public class UtviklerPortalDbContext : DbContext
{
    public UtviklerPortalDbContext(DbContextOptions<UtviklerPortalDbContext> options) : base(options)
    {
    }
    
    public DbSet<CompanyAccount> CompanyAccounts { get; set; }
    public DbSet<JobPost> JobPosts { get; set; }
}
