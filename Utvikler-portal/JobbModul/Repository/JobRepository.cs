using Microsoft.EntityFrameworkCore;
using Utvikler_portal.JobbModul.Models.Entities;
using Utvikler_portal.JobbModul.Repository.Interfaces;
using Utvikler_portal.Shared.Data;

namespace Utvikler_portal.JobbModul.Repository;

public class JobRepository : IJobRepository
{
    private readonly UtviklerPortalDbContext _dbContext;
    public JobRepository(UtviklerPortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<JobPost?> CreateJobAsync(JobPost jobpost)
    {
        var job = await _dbContext.JobPosts.AddAsync(jobpost);
        await _dbContext.SaveChangesAsync();

        if (job == null) return null;
        return job.Entity;
    }

    public async Task<JobPost?> DeleteJobAsync(Guid id)
    {
        var job = await _dbContext.JobPosts.FirstOrDefaultAsync(x => x.Id == id);
        if (job == null) return null;

        var entity = _dbContext.JobPosts.Remove(job);
        await _dbContext.SaveChangesAsync();

        return entity.Entity;
    }

    public async Task<ICollection<JobPost>> GetAllJobsAsync(int pageNr, int pageSize, string sortBy)
    {
        var jobs = await _dbContext.JobPosts
            .Skip(pageSize * (pageNr - 1))
            .Take(pageSize).ToListAsync();

        switch (sortBy)
        {
            case "Frist":
                jobs = jobs.OrderBy(x => x.Deadline).ToList();
                break;
            case "Publisert":
                jobs = jobs.OrderBy(x => x.Created).ToList();
                break;
            default:
                jobs = jobs.OrderBy(x => x.Created).ToList();
                break;
        }
        return jobs;
    }

    public async Task<JobPost?> GetJobByIdAsync(Guid id)
    {
        return await _dbContext.JobPosts.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<JobPost?> UpdateJobAsync(Guid id, JobPost jobpost)
    {
        await _dbContext.JobPosts.Where(x => x.Id == id)
            .ExecuteUpdateAsync(setters => setters
            .SetProperty(x => x.CompanyAccountId, jobpost.CompanyAccountId)
            .SetProperty(x => x.Employer, jobpost.Employer)
            .SetProperty(x => x.Position, jobpost.Position)
            .SetProperty(x => x.JuniorOrSenior, jobpost.JuniorOrSenior)
            .SetProperty(x => x.EmploymentType, jobpost.EmploymentType)
            .SetProperty(x => x.Location, jobpost.Location)
            .SetProperty(x => x.Deadline, jobpost.Deadline)
            .SetProperty(x => x.Title, jobpost.Title)
            .SetProperty(x => x.Description, jobpost.Description)
            .SetProperty(x => x.Tags, jobpost.Tags)
            .SetProperty(x => x.ContactOne, jobpost.ContactOne)
            .SetProperty(x => x.ContactTwo, jobpost.ContactTwo)
            .SetProperty(x => x.ContactOnePhone, jobpost.ContactOnePhone)
            .SetProperty(x => x.ContactTwoPhone, jobpost.ContactTwoPhone)
            .SetProperty(x => x.Updated, DateTime.Now));
        await _dbContext.SaveChangesAsync();

        var company = await _dbContext.JobPosts.FirstOrDefaultAsync(x => x.Id == id);
        if (company == null) return null;

        return company;
    }
}
