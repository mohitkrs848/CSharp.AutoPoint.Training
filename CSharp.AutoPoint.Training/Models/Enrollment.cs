using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Models
{
    internal class Enrollment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; } //Foreign key to Course

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; } //Foreign key to User

        public Course Course { get; set; } // Navigation property
        public User Student { get; set; } // Navigation property
    }
}
