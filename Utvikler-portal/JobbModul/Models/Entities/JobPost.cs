using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utvikler_portal.JobbModul.Models.DataAnnotations;

namespace Utvikler_portal.JobbModul.Models.Entities;

public class JobPost
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("CompanyAccountId")]
    public Guid CompanyAccountId { get; set; }

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,40}$")]
    public string Employer { get; set; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s.#-]{1,30}$")]
    public string Position { get; set; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-Z]{6}$")]
    public string JuniorOrSenior { get; set; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ]{1,20}$")]
    public string EmploymentType { get; set; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,30}$")]
    public string Location { get; set; } = string.Empty;

    [Required, DataType(DataType.Date), FutureDate, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Deadline { get; set; }

    [Required, RegularExpression(@"^[a-zA-Z0-9æøåÆØÅ][æøåÆØÅ!?.#^'%&\w\s+-]{1,100}$")]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [RegularExpression(@"^[a-zA-ZæøåÆØÅ\s,.#-]{1,100}$")]
    public string Tags { get; set; } = string.Empty;

    [Required, RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,40}$")]
    public string ContactOne { get; set; } = string.Empty;

    [RegularExpression(@"^[a-zA-ZæøåÆØÅ][a-zA-ZæøåÆØÅ\s]{1,40}$")]
    public string ContactTwo { get; set; } = string.Empty;

    [Phone]
    public string ContactOnePhone { get; set; } = string.Empty;

    [RegularExpression(@"^[0-9+-]{1,20}$")]
    public string ContactTwoPhone { get; set; } = string.Empty;

    [Required]
    public DateTime Created { get; set; }

    [Required]
    public DateTime Updated { get; set; }

    public virtual CompanyAccount? CompanyAccount { get; set; }
}
