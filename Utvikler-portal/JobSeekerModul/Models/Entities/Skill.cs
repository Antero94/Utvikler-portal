
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utvikler_portal.JobSeekerModul.Models.Entities
{
    public class Skill
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey ("UserId")]
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Level { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }

}

