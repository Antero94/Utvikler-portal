using System.ComponentModel.DataAnnotations;

namespace Utvikler_portal.JobbModul.Models.DTOs;

public class CompanyRegistrationDTO
{
    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,40}$")]
    public string CompanyName { get; init; } = string.Empty;

    [Phone]
    public string CompanyPhone { get; init; } = string.Empty;

    [EmailAddress]
    public string CompanyEmail { get; init; } = string.Empty;
}
