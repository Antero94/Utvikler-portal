using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class ExperienceController : ControllerBase
{

    private readonly IExperienceService _experienceService;

    public ExperienceController(IExperienceService experienceService)

    {
        _experienceService = experienceService;
    }

    [HttpGet("GetAllExperiences", Name = "GetAllExperiences")]
    public async Task<ActionResult<IEnumerable<ExperienceDTO>>> GetAllExperiences(int pageNr = 1, int pageSize = 10, string sortBy = "defaultSortProperty")
    {
        return Ok(await _experienceService.GetAllExperiencesAsync(pageNr, pageSize, sortBy));
    }

    [HttpGet("GetExperience", Name = "GetExperienceId")]
    public async Task<ActionResult<ExperienceDTO>> GetExperienceByIdAsync(Guid id)
    {
        var experience = await _experienceService.GetExperienceByIdAsync(id);
        if (experience == null)
            return NotFound($"Experience with ID {id} not found.");

        return Ok(experience);
    }

    [HttpPost("CreateExperience")]
    public async Task<ActionResult<ExperienceDTO>> CreateExperienceAsync(ExperienceDTO dTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        var experience = await _experienceService.CreateExperienceAsync(dTO);


        if (experience == null)
            return NotFound("Failed to create experience or error occurred.");

        return Ok(experience);
    }

    [HttpPut("UpdateExperience", Name = "UpdateExperience")]
    public async Task<ActionResult<ExperienceDTO>> UpdateExperienceAsync(Guid id, ExperienceDTO dTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var experience = await _experienceService.UpdateExperienceAsync(id, dTO);
        if (experience == null)
            return NotFound($"Experience with ID {id} not found.");

        return Ok(experience);
    }

    [HttpDelete("DeleteExperience", Name = "DeleteExperience")]
    public async Task<ActionResult<ExperienceDTO>> DeleteExperienceAsync(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _experienceService.DeleteExperienceAsync(id);

        return NoContent();
    }
}