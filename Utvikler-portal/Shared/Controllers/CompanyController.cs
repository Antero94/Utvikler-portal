using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost("CreateCompany")]
    public async Task<ActionResult<CompanyAccountDTO>> CreateCompanyAccountAsync(CompanyRegistrationDTO dto)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); };

        var company = await _companyService.CreateCompanyAccountAsync(dto);
        if (company == null) return BadRequest("Kunne ikke legge til konto");

        return Ok(company);
    }

    [HttpGet("GetAllCompanies", Name = "GetAllCompanies")]
    public async Task<ActionResult<IEnumerable<CompanyAccountDTO>>> GetAllCompaniesAsync(int pageNr = 1, int pageSize = 10)
    {
        return Ok(await _companyService.GetAllCompaniesAsync(pageNr, pageSize));
    }

    [HttpGet("GetCompany", Name = "GetCompany")]
    public async Task<ActionResult<CompanyAccountDTO>> GetCompanyAsync(Guid id)
    {
        var company = await _companyService.GetCompanyByIdAsync(id);
        if (company == null) return NotFound("Fant ikke bruker");

        return Ok(company);
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
