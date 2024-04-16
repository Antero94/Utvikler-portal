
namespace Utvikler_portal.JobSeekerModul.Models.Entities;

public class Education
{
    public Guid Id { get; internal set; }
    public string School { get; set; }
    public string Degree { get; set; }
    public string FieldOfStudy { get; set; }
    public DateTime GraduationDate { get; set; }
   
}

