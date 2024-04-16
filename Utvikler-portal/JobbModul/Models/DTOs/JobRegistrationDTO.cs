using System.ComponentModel.DataAnnotations;

namespace Utvikler_portal.JobbModul.Models.DTOs;

public class JobRegistrationDTO
{
    public Guid CompanyAccountId { get; init; }

    public string Employer { get; init; } = string.Empty;

    public string Position { get; init; } = string.Empty;

    public string JuniorOrSenior { get; init; } = string.Empty;

    public string EmploymentType { get; init; } = string.Empty;

    public string Location { get; init; } = string.Empty;

    public DateTime Deadline { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string Tags { get; init; } = string.Empty;

    public string ContactOne { get; init; } = string.Empty;

    public string ContactTwo { get; init; } = string.Empty;

    public string ContactOnePhone { get; init; } = string.Empty;

    public string ContactTwoPhone { get; init; } = string.Empty;

    public DateTime Created { get; init; }

    public DateTime Updated { get; init; }
}
