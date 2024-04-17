using Utvikler_portal.JobbModul.Models.Entities;

namespace Utvikler_portal.JobbModul.Repository.Interfaces;

public interface IJobRepository
{
    Task<ICollection<JobPost>> GetAllJobsAsync(int pageNr, int pageSize, string sortBy);
    Task<ICollection<JobPost>> GetCompanySpecificJobsAsync(Guid id, int pageNr, int pageSize);
    Task<JobPost?> GetJobByIdAsync(Guid id);
    Task<JobPost?> CreateJobAsync(JobPost jobpost);
    Task<JobPost?> UpdateJobAsync(Guid id, JobPost jobpost);
    Task<JobPost?> DeleteJobAsync(Guid id);
}
