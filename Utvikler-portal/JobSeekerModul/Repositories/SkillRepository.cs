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
    public class SkillRepository : ISkillRepository
    {
        private readonly UtviklerPortalDbContext _dbContext;

        public SkillRepository(UtviklerPortalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync(int pageNr, int pageSize, string sortBy)
        {
            IQueryable<Skill> query = _dbContext.Skills;



            return await query.Skip(pageSize * (pageNr - 1)).Take(pageSize).ToListAsync();
        }

        public async Task<Skill?> GetSkillByIdAsync(Guid id)
        {
            return await _dbContext.Skills.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Skill> CreateSkillAsync(Skill skill)
        {
            _dbContext.Skills.Add(skill);
            await _dbContext.SaveChangesAsync();
            return skill;
        }

        public async Task<Skill?> UpdateSkillAsync(Guid id, Skill updatedSkill)
        {
            var skill = await _dbContext.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if (skill != null)
            {
                skill.Name = updatedSkill.Name;
                skill.Level = updatedSkill.Level;
                await _dbContext.SaveChangesAsync();
            }
            return skill;
        }

        public async Task DeleteSkillAsync(Guid id)
        {
            var skill = await _dbContext.Skills.FirstOrDefaultAsync(x => x.Id == id);
            if (skill != null)
            {
                _dbContext.Skills.Remove(skill);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
