using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet("GetAllJobs", Name = "GetAllJobs")]
    public async Task<ActionResult<IEnumerable<JobPostDTO>>> GetAllJobsAsync(int pageNr = 1, int pageSize = 10, string sortBy = "")
    {
        return Ok(await _jobService.GetAllJobsAsync(pageNr, pageSize, sortBy));
    }

    [HttpGet("GetJob={jobId:Guid}", Name = "GetJob")]
    public async Task<ActionResult<JobPostDTO>> GetJobAsync(Guid id)
    {
        var job = await _jobService.GetJobByIdAsync(id);
        if (job == null) return NotFound("Job not found");

        return Ok(job);
    }

    [Authorize]
    [HttpPost("CreateJob")]
    public async Task<ActionResult<JobPostDTO>> CreateJobAsync(JobRegistrationDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var job = await _jobService.CreateJobAsync(dto);
        if (job == null) return BadRequest("Something went wrong");

        return Ok(job);
    }

    [Authorize]
    [HttpPut("UpdateJob={jobId:Guid}", Name = "UpdateJob")]
    public async Task<ActionResult<JobPostDTO>> UpdateJobAsync(Guid id, JobPostDTO jobPostDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var job = await _jobService.UpdateJobAsync(id, jobPostDTO);
        if (job == null) return NotFound("Job not found");

        return Ok(job);
    }

    [Authorize]
    [HttpDelete("DeleteJob={jobId:Guid}", Name = "DeleteJob")]
    public async Task<ActionResult<JobPostDTO>> DeleteJobAsync(Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var job = await _jobService.DeleteJobAsync(id);
        if (job == null) return NotFound("Job not found");

        return Ok(job);
    }
}
