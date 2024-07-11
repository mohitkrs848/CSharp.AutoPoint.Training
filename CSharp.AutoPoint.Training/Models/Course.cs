using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Models
{
    internal class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int InstructorId { get; set; } //Foreign key to User

        public User Instructor { get; set; } // Navigation property

        public ICollection<Enrollment> Enrollments { get; set; } // Navigation property
    }
}
