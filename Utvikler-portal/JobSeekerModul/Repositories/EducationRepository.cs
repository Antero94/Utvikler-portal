using Microsoft.EntityFrameworkCore;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utvikler_portal.JobSeekerModul.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly UtviklerPortalDbContext _dbContext;

        public EducationRepository(UtviklerPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Education>> GetAllEducationsAsync(int pageNr, int pageSize, string sortBy)
        {
            IQueryable<Education> query = _dbContext.Educations;



            return await query.Skip(pageSize * (pageNr - 1)).Take(pageSize).ToListAsync();
        }

        public async Task<Education?> GetEducationByIdAsync(Guid id)
        {
            return await _dbContext.Educations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Education> CreateEducationAsync(Education education)
        {
            _dbContext.Educations.Add(education);
            await _dbContext.SaveChangesAsync();
            return education;
        }

        public async Task<Education?> UpdateEducationAsync(Guid id, Education updatedEducation)
        {
            var education = await _dbContext.Educations.FirstOrDefaultAsync(x => x.Id == id);
            if (education != null)
            {
                education.School = updatedEducation.School;
                education.Degree = updatedEducation.Degree;
                education.FieldOfStudy = updatedEducation.FieldOfStudy;
                education.GraduationDate = updatedEducation.GraduationDate;
                await _dbContext.SaveChangesAsync();
            }
            return education;
        }

        public async Task DeleteEducationAsync(Guid id)
        {
            var education = await _dbContext.Educations.FirstOrDefaultAsync(x => x.Id == id);
            if (education != null)
            {
                _dbContext.Educations.Remove(education);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
