using System.ComponentModel.DataAnnotations;

namespace Utvikler_portal.Models.Entities;

public class UserAccount
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(2), MaxLength(20)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MinLength(2), MaxLength(20)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MinLength(1), MaxLength(30)]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(3), MaxLength(30)]
    public string UserName { get; set; } = string.Empty;

    public string HashedPassword { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    [Required]
    public bool IsAdmin { get; set; }

    [Required]
    public DateTime Created { get; set; }

    [Required]
    public DateTime Updated { get; set; }
}
