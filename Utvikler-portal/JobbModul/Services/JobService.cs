using System.Security.Claims;
using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;
using Utvikler_portal.JobbModul.Repository.Interfaces;
using Utvikler_portal.JobbModul.Services.Interfaces;

namespace Utvikler_portal.JobbModul.Services;

public class JobService : IJobService
{
    private readonly IMapper<JobPost, JobPostDTO> _jobMapper;
    private readonly IMapper<JobPost, JobRegistrationDTO> _jobRegistrationMapper;
    private readonly IJobRepository _jobRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public JobService(IMapper<JobPost, JobPostDTO> jobMapper, IMapper<JobPost, JobRegistrationDTO> jobRegistrationMapper,IJobRepository jobRepository, IHttpContextAccessor httpContextAccessor)
    {
        _jobMapper = jobMapper;
        _jobRegistrationMapper = jobRegistrationMapper;
        _jobRepository = jobRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<JobPostDTO?> CreateJobAsync(JobRegistrationDTO dto)
    {
        var job = _jobRegistrationMapper.MapToModel(dto);
        //string companyId = _httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        //job.CompanyAccountId = new Guid(companyId);
        var res = await _jobRepository.CreateJobAsync(job);
        if (res == null) return null;
        return _jobMapper.MapToDTO(res);
    }

    public async Task<JobPostDTO?> DeleteJobAsync(Guid id)
    {
        var job = await _jobRepository.GetJobByIdAsync(id);
        if (job == null) return null;

        var res = await _jobRepository.DeleteJobAsync(id);
        return res != null ? _jobMapper.MapToDTO(job) : null;
    }

    public async Task<ICollection<JobPostDTO>> GetAllJobsAsync(int pageNr, int pageSize, string sortBy)
    {
        var jobs = await _jobRepository.GetAllJobsAsync(pageNr, pageSize, sortBy);
        var dto = jobs.Select(_jobMapper.MapToDTO).ToList();

        return dto;
    }

    public async Task<JobPostDTO?> GetJobByIdAsync(Guid id)
    {
        var job = await _jobRepository.GetJobByIdAsync(id);
        if (job == null) return null;

        return _jobMapper.MapToDTO(job);
    }

    public async Task<JobPostDTO?> UpdateJobAsync(Guid id, JobPostDTO dto)
    {
        var job = await _jobRepository.GetJobByIdAsync(id);
        if (job == null) return null;

        var jobUpdated = _jobMapper.MapToModel(dto);
        jobUpdated.Id = id;
        //string companyId = _httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
        //jobUpdated.CompanyAccountId = new Guid(); //new Guid(companyId);
        var res = await _jobRepository.UpdateJobAsync(id, jobUpdated);
        return res != null ? _jobMapper.MapToDTO(jobUpdated) : null;
    }
}
