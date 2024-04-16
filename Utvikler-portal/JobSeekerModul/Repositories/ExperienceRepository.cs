using Utvikler_portal.JobSeekerModul.Data;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repository
{
	public class ExperienceRepository : IExperienceRepository
	{
        private readonly UserContext _context;

        public ExperienceRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Experience>> GetAllExperiencesAsync()
        {
            return await _context.Experiences.ToListAsync();
        }

        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            return await _context.Experiences.FindAsync(id);
        }

        public async Task<Experience> AddExperienceAsync(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();
            return experience;
        }

        public async Task<Experience> UpdateExperienceAsync(Experience experience)
        {
            _context.Entry(experience).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return experience;
        }

        public async Task DeleteExperienceAsync(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience != null)
            {
                _context.Experiences.Remove(experience);
                await _context.SaveChangesAsync();
            }
        }
    }
}

