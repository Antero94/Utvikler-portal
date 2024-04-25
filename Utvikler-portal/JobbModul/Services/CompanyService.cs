using System.Security.Claims;
using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;
using Utvikler_portal.JobbModul.Repository.Interfaces;
using Utvikler_portal.JobbModul.Services.Interfaces;

namespace Utvikler_portal.JobbModul.Services;

public class CompanyService : ICompanyService
{
    private readonly IMapper<CompanyAccount, CompanyRegistrationDTO> _registrationMapper;
    private readonly IMapper<CompanyAccount, CompanyAccountDTO> _companyMapper;
    private readonly ICompanyRepository _companyRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CompanyService(IMapper<CompanyAccount, CompanyAccountDTO> companyMapper, IMapper<CompanyAccount, CompanyRegistrationDTO> registrationMapper,
            ICompanyRepository companyRepository, IHttpContextAccessor httpContextAccessor)
    {
        _companyMapper = companyMapper;
        _companyRepository = companyRepository;
        _registrationMapper = registrationMapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<CompanyAccountDTO?> CreateCompanyAccountAsync(CompanyRegistrationDTO dto, Guid userId)
    {
        var company = _registrationMapper.MapToModel(dto);
        string companyId = _httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

        if (Guid.TryParse(companyId, out Guid id) && id == userId)
        {
            company.Id = userId;
            var res = await _companyRepository.CreateCompanyAccountAsync(company);
            return res != null ? _companyMapper.MapToDTO(res) : null;
        }
        return null;
    }

    public async Task<CompanyAccountDTO?> DeleteAsync(Guid id)
    {
        var company = await _companyRepository.GetCompanyByIdAsync(id);
        if (company == null) return null;

        var res = await _companyRepository.DeleteAsync(id);
        if (res == null) return null;

        return _companyMapper.MapToDTO(company);
    }

    public async Task<ICollection<CompanyAccountDTO>> GetAllCompaniesAsync(int pageNr, int pageSize)
    {
        var companies = await _companyRepository.GetAllCompaniesAsync(pageNr, pageSize);
        var dtos = companies.Select(_companyMapper.MapToDTO).ToList();

        return dtos;
    }

    public async Task<CompanyAccountDTO?> GetCompanyByIdAsync(Guid id)
    {
        var company = await _companyRepository.GetCompanyByIdAsync(id);
        if (company == null) return null;

        return _companyMapper.MapToDTO(company);
    }

    public async Task<CompanyAccountDTO?> UpdateAsync(Guid id, CompanyAccountDTO dto)
    {
        var company = await _companyRepository.GetCompanyByIdAsync(id);
        if (company == null) return null;

        var companyUpdated = _companyMapper.MapToModel(dto);
        companyUpdated.Id = id;

        var res = await _companyRepository.UpdateAsync(id, companyUpdated);
        return res != null ? _companyMapper.MapToDTO(companyUpdated) : null;
    }
}
