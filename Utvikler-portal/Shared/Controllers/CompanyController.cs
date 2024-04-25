using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IJobService _jobService;
    public CompanyController(ICompanyService companyService, IJobService jobService)
    {
        _companyService = companyService;
        _jobService = jobService;
    }

    [HttpPost("CreateCompany")]
    [Authorize]
    public async Task<ActionResult<CompanyAccountDTO>> CreateCompanyAccountAsync(CompanyRegistrationDTO dto, Guid userId)
    {
        var company = await _companyService.CreateCompanyAccountAsync(dto, userId);
        if (company == null) return BadRequest("Kunne ikke legge til konto");

        return Ok(company);
    }

    [HttpGet("GetAllCompanies", Name = "GetAllCompanies")]
    public async Task<ActionResult<IEnumerable<CompanyAccountDTO>>> GetAllCompaniesAsync(int pageNr = 1, int pageSize = 10)
    {
        return Ok(await _companyService.GetAllCompaniesAsync(pageNr, pageSize));
    }

    [HttpGet("GetCompany={userId:Guid}", Name = "GetCompany")]
    public async Task<ActionResult<CompanyAccountDTO>> GetCompanyAsync(Guid userId)
    {
        var company = await _companyService.GetCompanyByIdAsync(userId);
        if (company == null) return NotFound("Fant ikke bruker");

        return Ok(company);
    }

    [HttpGet("GetJobPosts={userId:Guid}", Name = "GetJobPosts")]
    public async Task<ActionResult<IEnumerable<JobPostDTO>>> GetJobPostsAsync(Guid userId, int pageNr = 1, int pageSize = 10)
    {
        return Ok(await _jobService.GetCompanySpecificJobsAsync(userId, pageNr, pageSize));
    }

    [HttpPut("UpdateCompany", Name = "UpdateCompany")]
    public async Task<ActionResult<CompanyAccountDTO>> UpdateCompanyAsync(Guid id, CompanyAccountDTO companyDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var company = await _companyService.UpdateAsync(id, companyDTO);
        if (company == null) return NotFound("Fant ikke bruker");

        return Ok(company);
    }

    [HttpDelete("DeleteCompany", Name = "DeleteCompany")]
    public async Task<ActionResult<CompanyAccountDTO>> DeleteCompanyAsync(Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var company = await _companyService.DeleteAsync(id);
        if (company == null) return NotFound("Fant ikke bruker");

        return Ok(company);
    }
}
