using Utvikler_portal.JobbModul.Mappers.Interface;
using Utvikler_portal.JobbModul.Models.DTOs;
using Utvikler_portal.JobbModul.Models.Entities;

namespace Utvikler_portal.JobbModul.Mappers;

public class JobRegistrationMapper : IMapper<JobPost, JobRegistrationDTO>
{
    public JobRegistrationDTO MapToDTO(JobPost model)
    {
        throw new NotImplementedException();
    }

    public JobPost MapToModel(JobRegistrationDTO dto)
    {
        var dtNow = DateTime.Now;

        return new JobPost
        {
            CompanyAccountId = dto.CompanyAccountId,
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
            Created = dtNow,
            Updated = dtNow
        };
    }
}
