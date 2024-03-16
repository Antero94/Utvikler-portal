using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utvikler_portal.Models.Entities;

public class JobPost
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("CompanyAccountId")]
    public int CompanyAccountId { get; set; }

    [Required]
    [MinLength(1), MaxLength(30)]
    public string Employer { get; set; } = string.Empty;

    [Required]
    [MinLength(1), MaxLength(30)]
    public string Position { get; set; } = string.Empty;

    [Required]
    [MinLength(1), MaxLength(6)]
    public string JuniorOrSenior { get; set; } = string.Empty;

    [Required]
    [MinLength(1), MaxLength(30)]
    public string EmploymentType { get; set; } = string.Empty;

    [Required]
    [MinLength(1), MaxLength(30)]
    public string Location { get; set; } = string.Empty;

    [Required]
    public DateTime Deadline { get; set; }

    [Required]
    [MinLength(1), MaxLength(30)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public string Tags { get; set; } = string.Empty;

    [Required]
    [MinLength(2), MaxLength(20)]
    public string ContactOne { get; set; } = string.Empty;

    [MinLength(2), MaxLength(20)]
    public string ContactTwo { get; set; } = string.Empty;

    [Required]
    [MinLength(1), MaxLength(30)]
    public string ContactOnePhone { get; set; } = string.Empty;

    [MinLength(1), MaxLength(30)]
    public string ContactTwoPhone { get; set; } = string.Empty;

    [Required]
    public DateTime Created { get; set; }

    [Required]
    public DateTime Updated { get; set; }

    public virtual CompanyAccount? CompanyAccount { get; set; }
}
