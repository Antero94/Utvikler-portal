using System.ComponentModel.DataAnnotations;

namespace Utvikler_portal.JobbModul.Models.Entities;

public class CompanyAccount
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MinLength(1), MaxLength(30)]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [MinLength(1), MaxLength(30)]
    public string CompanyPhone { get; set; } = string.Empty;

    [EmailAddress]
    public string CompanyEmail { get; set; } = string.Empty;

    [Required]
    public DateTime Created { get; set; }

    [Required]
    public DateTime Updated { get; set; }

    public virtual ICollection<JobPost> JobPosts { get; set; } = new HashSet<JobPost>();
}
