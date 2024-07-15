using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; } //Foreign key to Course
        public Course Course { get; set; } // Navigation property

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; } //Foreign key to User
        public User Student { get; set; } // Navigation property
    }
}
