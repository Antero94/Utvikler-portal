using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("GetAllSkills", Name = "GetAllSkills")]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpGet("GetSkill", Name = "GetSkillId")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        [HttpPost("CreateSkill")]
        public async Task<IActionResult> CreateSkill(SkillDTO skillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdSkill = await _skillService.CreateSkillAsync(skillDto);


            if (createdSkill == null)
            {
                return NotFound("Failed to create skill or error occurred.");
            }


            return CreatedAtAction(nameof(GetSkillById), new { id = createdSkill.Id }, createdSkill);
        }



        [HttpPut("UpdateSkill", Name = "UpdateSkill")]
        public async Task<IActionResult> UpdateSkill(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var skillToUpdate = await _skillService.GetSkillByIdAsync(id);
            if (skillToUpdate == null)
            {
                return NotFound($"Skill with ID {id} not found.");
            }

            await _skillService.UpdateSkillAsync(id);

            return NoContent();
        }


        [HttpDelete("DeleteSkill", Name = "DeleteSkill")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skillToDelete = await _skillService.GetSkillByIdAsync(id);
            if (skillToDelete == null)
            {
                return NotFound($"Skill with ID {id} not found.");
            }

            await _skillService.DeleteSkillAsync(id);
            return NoContent();
        }
    }
}
