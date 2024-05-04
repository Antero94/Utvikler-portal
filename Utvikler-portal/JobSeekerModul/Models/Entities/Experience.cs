using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utvikler_portal.JobSeekerModul.Models.Entities;

public class Experience
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("UserId")]
    public Guid UserId { get; set; }

    [Required]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    public string Position { get; set; } = string.Empty;

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public DateTime Created { get; set; }
}