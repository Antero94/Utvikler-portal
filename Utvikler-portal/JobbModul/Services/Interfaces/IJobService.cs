using Utvikler_portal.JobbModul.Models.DTOs;

namespace Utvikler_portal.JobbModul.Services.Interfaces;

public interface IJobService
{
    Task<ICollection<JobPostDTO>> GetAllJobsAsync(int pageNr, int pageSize, string sortBy);
    Task<ICollection<JobPostDTO>> GetCompanySpecificJobsAsync(Guid id, int pageNr, int pageSize);
    Task<JobPostDTO?> GetJobByIdAsync(Guid id);
    Task<JobPostDTO?> CreateJobAsync(JobRegistrationDTO dto);
    Task<JobPostDTO?> UpdateJobAsync(Guid id, JobPostDTO dto);
    Task<JobPostDTO?> DeleteJobAsync(Guid id);
}
