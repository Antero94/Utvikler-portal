using System.ComponentModel.DataAnnotations;
using Utvikler_portal.JobbModul.Models.DataAnnotations;

namespace Utvikler_portal.JobbModul.Models.DTOs;

public class JobRegistrationDTO
{
    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,40}$")]
    public string Employer { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s.#-]{1,30}$")]
    public string Position { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-Z]{6}$")]
    public string JuniorOrSenior { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ]{1,20}$")]
    public string EmploymentType { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,30}$")]
    public string Location { get; init; } = string.Empty;

    [Required, DataType(DataType.Date), FutureDate, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Deadline { get; init; }

    [Required, RegularExpression(@"^[a-zA-Z0-9æøåÆØÅ][æøåÆØÅ!?.#^'%&\w\s+-]{1,100}$")]
    public string Title { get; init; } = string.Empty;

    [Required, MaxLength(1000)]
    public string Description { get; init; } = string.Empty;

    [RegularExpression(@"^[a-zA-ZæøåÆØÅ\s,.#-]{1,100}$")]
    public string Tags { get; init; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,40}$")]
    public string ContactOne { get; init; } = string.Empty;

    [RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,40}$")]
    public string ContactTwo { get; init; } = string.Empty;

    [Phone]
    public string ContactOnePhone { get; init; } = string.Empty;

    [RegularExpression(@"^[0-9+-]{1,20}$")]
    public string ContactTwoPhone { get; init; } = string.Empty;
}
