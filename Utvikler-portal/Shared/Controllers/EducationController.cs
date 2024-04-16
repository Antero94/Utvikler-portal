using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet("GetAllEducations", Name = "GetEducations")]
        public async Task<IActionResult> GetAllEducations()
        {
            var educations = await _educationService.GetAllEducationsAsync();
            return Ok(educations);
        }

        [HttpGet("GetEducation", Name = "GetEducationId")]
        public async Task<IActionResult> GetEducationById(int id)
        {
            var education = await _educationService.GetEducationByIdAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            return Ok(education);
        }

        [HttpPost("CreateEducation")]
        public async Task<IActionResult> CreateEducation(EducationDTO educationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdEducation = await _educationService.CreateEducationAsync(educationDto);


            if (createdEducation == null)
            {
                return NotFound("Failed to create education or error occurred.");
            }

        
            return CreatedAtAction(nameof(GetEducationById), new { id = createdEducation.Id }, createdEducation);
        }



        [HttpPut("UpdateEducation", Name = "UpdateEducation")]
        public async Task<IActionResult> UpdateEducation(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var educationToUpdate = await _educationService.GetEducationByIdAsync(id);
            if (educationToUpdate == null)
            {
                return NotFound($"Education with ID {id} not found.");
            }

            await _educationService.UpdateEducationAsync(id);

            return NoContent();
        }

        [HttpDelete("DeleteEducation", Name = "DeleteEducation")]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var educationToDelete = await _educationService.GetEducationByIdAsync(id);
            if (educationToDelete == null)
            {
                return NotFound($"Education with ID {id} not found.");
            }

            await _educationService.DeleteEducationAsync(id);
            return NoContent();
        }
    }

}        