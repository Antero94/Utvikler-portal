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
    public string School { get; set; }

    [Required]
    public string Degree { get; set; }

    [Required]
    public string FieldOfStudy { get; set; }

    [Required]
    public DateTime GraduationDate { get; set; }
}

