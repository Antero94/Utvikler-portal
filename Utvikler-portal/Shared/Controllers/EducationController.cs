using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class EducationController : ControllerBase
{

    private readonly IEducationService _educationService;

    public EducationController(IEducationService educationService)

    {
        _educationService = educationService;
    }

    [HttpGet("GetAllEducations", Name = "GetAllEducations")]
    public async Task<ActionResult<IEnumerable<EducationDTO>>> GetAllEducations(int pageNr = 1, int pageSize = 10, string sortBy = "defaultSortProperty")
    {
        return Ok(await _educationService.GetAllEducationsAsync(pageNr, pageSize, sortBy));
    }

    [HttpGet("GetEducation", Name = "GetEducationId")]
    public async Task<ActionResult<EducationDTO>> GetEducationByIdAsync(Guid id)
    {
        var education = await _educationService.GetEducationByIdAsync(id);
        if (education == null)
            return NotFound($"Education with ID {id} not found.");

        return Ok(education);
    }

    [HttpPost("CreateEducation")]
    public async Task<ActionResult<EducationDTO>> CreateEducationAsync(EducationDTO dTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        var education = await _educationService.CreateEducationAsync(dTO);

        if (education == null)
            return NotFound("Failed to create education or error occurred.");

        return Ok(education);
    }

    [HttpPut("UpdateEducation", Name = "UpdateEducation")]
    public async Task<ActionResult<EducationDTO>> UpdateEducationAsync(Guid id, EducationDTO dTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var education = await _educationService.UpdateEducationAsync(id, dTO);
        if (education == null)
            return NotFound($"Education with ID {id} not found.");

        return Ok(education);
    }

    [HttpDelete("DeleteEducation", Name = "DeleteEducation")]
    public async Task<ActionResult<EducationDTO>> DeleteEducationAsync(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _educationService.DeleteEducationAsync(id);

        return NoContent();
    }
}