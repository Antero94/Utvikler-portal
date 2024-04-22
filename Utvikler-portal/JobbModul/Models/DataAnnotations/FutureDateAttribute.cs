using System.ComponentModel.DataAnnotations;

namespace Utvikler_portal.JobbModul.Models.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        return value is DateTime date && date > DateTime.UtcNow
            ? ValidationResult.Success
            : new ValidationResult("Deadline må være en fremtidig dato");
    }
}
