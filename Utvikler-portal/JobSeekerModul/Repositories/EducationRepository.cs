using Utvikler_portal.JobSeekerModul.Data;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.Entities;

namespace Utvikler_portal.JobSeekerModul.Repository
{
    public class EducationRepository : IEducationRepository
	{
        private readonly UserContext _context;

        public EducationRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Education>> GetAllEducationsAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education> GetEducationByIdAsync(int id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task<Education> AddEducationAsync(Education education)
        {
            _context.Educations.Add(education);
            await _context.SaveChangesAsync();
            return education;
        }
        public async Task<Education> UpdateEducationAsync(Education education)
        {
            _context.Entry(education).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return education;
        }

        public async Task DeleteEducationAsync(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
                await _context.SaveChangesAsync();
            }
        }

    }
}

