using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers;

[Route("api/[controller]")]
[ApiController, Authorize]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet("GetAllSkills", Name = "GetAllSkills")]
    public async Task<ActionResult<IEnumerable<SkillDTO>>> GetAllSkills(int pageNr = 1, int pageSize = 10, string sortBy = "defaultSortProperty")
    {
        return Ok(await _skillService.GetAllSkillsAsync(pageNr, pageSize, sortBy));
    }

    [HttpGet("GetSkill", Name = "GetSkillId")]
    public async Task<ActionResult<SkillDTO>> GetSkillByIdAsync(Guid id)
    {
        var skill = await _skillService.GetSkillByIdAsync(id);
        if (skill == null)
            return NotFound($"Skill with ID {id} not found.");

        return Ok(skill);
    }

    [HttpPost("CreateSkill")]
    public async Task<ActionResult<SkillDTO>> CreateSkillAsync(SkillDTO dTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        var skill = await _skillService.CreateSkillAsync(dTO);


        if (skill == null)
            return NotFound("Failed to create skill or error occurred.");

        return Ok(skill);
    }

    [HttpPut("UpdateSkill", Name = "UpdateSkill")]
    public async Task<ActionResult<SkillDTO>> UpdateSkillAsync(Guid id, SkillDTO dTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var skill = await _skillService.UpdateSkillAsync(id, dTO);
        if (skill == null)

            return NotFound($"Skill with ID {id} not found.");

        return Ok(skill);
    }

    [HttpDelete("DeleteSkill", Name = "DeleteSkill")]
    public async Task<IActionResult> DeleteSkillAsync(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _skillService.DeleteSkillAsync(id);

        return NoContent();
    }
}