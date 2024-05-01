namespace Utvikler_portal.JobSeekerModul.Models.DTOs;

	public record ExperienceDTO(

        Guid Id,
        Guid UserId,
        string CompanyName,
        string Position,
        DateTime StartDate,
        DateTime EndDate);

