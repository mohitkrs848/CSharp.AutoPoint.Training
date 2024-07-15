using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharp.AutoPoint.Training.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        //public int InstructorId { get; set; } //Foreign key to User

        //public User Instructor { get; set; } // Navigation property

        public ICollection<Enrollment> Enrollments { get; set; } // Navigation property
    }
}
