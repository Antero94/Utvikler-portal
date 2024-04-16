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
    public CompanyService(IMapper<CompanyAccount, CompanyAccountDTO> companyMapper, IMapper<CompanyAccount, CompanyRegistrationDTO> registrationMapper, ICompanyRepository companyRepository)
    {
        _companyMapper = companyMapper;
        _companyRepository = companyRepository;
        _registrationMapper = registrationMapper;
    }

    public async Task<CompanyAccountDTO?> CreateCompanyAccountAsync(CompanyRegistrationDTO dto)
    {
        var company = _registrationMapper.MapToModel(dto);

        var res = await _companyRepository.CreateCompanyAccountAsync(company);
        if (res == null) return null;
        return _companyMapper.MapToDTO(res!);
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
