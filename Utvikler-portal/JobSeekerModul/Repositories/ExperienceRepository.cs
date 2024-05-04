using Microsoft.EntityFrameworkCore;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.Shared.Data;

namespace Utvikler_portal.JobSeekerModul.Repositories;

public class ExperienceRepository : IExperienceRepository
{
    private readonly UtviklerPortalDbContext _dbContext;

    public ExperienceRepository(UtviklerPortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Experience>> GetAllExperiencesAsync(int pageNr, int pageSize, string sortBy)
    {
        IQueryable<Experience> query = _dbContext.Experiences;
        return await query.Skip(pageSize * (pageNr - 1)).Take(pageSize).ToListAsync();
    }

    public async Task<Experience?> GetExperienceByIdAsync(Guid id)
    {
        return await _dbContext.Experiences.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Experience> CreateExperienceAsync(Experience experience)
    {
        _dbContext.Experiences.Add(experience);
        await _dbContext.SaveChangesAsync();
        return experience;
    }

    public async Task<Experience?> UpdateExperienceAsync(Guid id, Experience updatedExperience)
    {
        var experience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.Id == id);
        if (experience != null)
        {
            experience.CompanyName = updatedExperience.CompanyName;
            experience.Position = updatedExperience.Position;
            experience.StartDate = updatedExperience.StartDate;
            experience.EndDate = updatedExperience.EndDate;
            await _dbContext.SaveChangesAsync();
        }
        return experience;
    }

    public async Task DeleteExperienceAsync(Guid id)
    {
        var experience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.Id == id);
        if (experience != null)
        {
            _dbContext.Experiences.Remove(experience);
            await _dbContext.SaveChangesAsync();
        }
    }
}
