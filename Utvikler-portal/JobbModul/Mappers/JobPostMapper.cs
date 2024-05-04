using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;

namespace Utvikler_portal.JobbModul.Mappers;

public class JobPostMapper : IMapper<JobPost, JobPostDTO>
{
    public JobPostDTO MapToDTO(JobPost model)
    {
        return new JobPostDTO(
            model.Id,
            model.CompanyAccountId,
            model.Employer,
            model.Position,
            model.JuniorOrSenior,
            model.EmploymentType,
            model.Location,
            model.Deadline,
            model.Title,
            model.Description,
            model.Tags,
            model.ContactOne,
            model.ContactTwo,
            model.ContactOnePhone,
            model.ContactTwoPhone,
            model.Created.ToLocalTime(),
            model.Updated.ToLocalTime());
    }

    public JobPost MapToModel(JobPostDTO dto)
    {
        var dtNow = DateTime.UtcNow;

        return new JobPost()
        {
            Employer = dto.Employer,
            Position = dto.Position,
            JuniorOrSenior = dto.JuniorOrSenior,
            EmploymentType = dto.EmploymentType,
            Location = dto.Location,
            Deadline = dto.Deadline,
            Title = dto.Title,
            Description = dto.Description,
            Tags = dto.Tags,
            ContactOne = dto.ContactOne,
            ContactTwo = dto.ContactTwo,
            ContactOnePhone = dto.ContactOnePhone,
            ContactTwoPhone = dto.ContactTwoPhone,
            Updated = dtNow
        };
    }
}
