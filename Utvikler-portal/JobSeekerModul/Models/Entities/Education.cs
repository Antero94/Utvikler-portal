using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utvikler_portal.JobSeekerModul.Models.Entities;

public class Education
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("UserId")]
    public Guid UserId { get; set; }

    [Required]
    public string School { get; set; } = string.Empty;

    [Required]
    public string Degree { get; set; } = string.Empty;

    [Required]
    public string FieldOfStudy { get; set; } = string.Empty;

    [Required]
    public DateTime GraduationDate { get; set; }
}

