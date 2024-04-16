
namespace Utvikler_portal.JobSeekerModul.Models.Entities;

public class Experience
{
    public Guid Id { get; internal set; }
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}