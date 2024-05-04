using System.ComponentModel.DataAnnotations;

namespace Utvikler_portal.JobSeekerModul.Models.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MinLength(2), MaxLength(20)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MinLength(2), MaxLength(20)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateTime Created { get; set; }

    [Required]
    public DateTime Updated { get; set; }

    public List<Experience> Experiences { get; set; } = new List<Experience>();
    public List<Skill> Skills { get; set; } = new List<Skill>();
    public List<Education> Educations { get; set; } = new List<Education>();
}
