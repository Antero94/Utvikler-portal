using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet("GetAllExperiences", Name = "GetAllExperiences")]
        public async Task<IActionResult> GetAllExperiences()
        {
            var experiences = await _experienceService.GetAllExperiencesAsync();
            return Ok(experiences);
        }

        [HttpGet("GetExperience", Name = "GetExperienceId")]
        public async Task<IActionResult> GetExperienceById(int id)
        {
            var experience = await _experienceService.GetExperienceByIdAsync(id);
            if (experience == null)
            {
                return NotFound();
            }
            return Ok(experience);
        }

        [HttpPost("CreateExperience")]
        public async Task<IActionResult> CreateExperience(ExperienceDTO experienceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdExperience = await _experienceService.CreateExperienceAsync(experienceDto);


            if (createdExperience == null)
            {
                return NotFound("Failed to create experience or error occurred.");
            }


            return CreatedAtAction(nameof(GetExperienceById), new { id = createdExperience.Id }, createdExperience);
        }



        [HttpPut("UpdateExperience", Name = "UpdateExperience")]
        public async Task<IActionResult> UpdateExperience(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var experienceToUpdate = await _experienceService.GetExperienceByIdAsync(id);
            if (experienceToUpdate == null)
            {
                return NotFound($"Experience with ID {id} not found.");
            }

            await _experienceService.UpdateExperienceAsync(id);

            return NoContent();
        }

        [HttpDelete("DeleteExperience", Name = "DeleteExperience")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var experienceToDelete = await _experienceService.GetExperienceByIdAsync(id);
            if (experienceToDelete == null)
            {
                return NotFound($"Experience with ID {id} not found.");
            }

            await _experienceService.DeleteExperienceAsync(id);
            return NoContent();
        }
    }
}
