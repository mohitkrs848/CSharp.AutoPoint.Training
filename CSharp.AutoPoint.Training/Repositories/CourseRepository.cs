using CSharp.AutoPoint.Training.Data;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Repositories
{
    internal class CourseRepository : ICourseRepository
    {
        private readonly LMSDbContext _context;
        public CourseRepository(LMSDbContext context)
        {
            _context = context;
        }
        public Course GetCourseById(int id) => _context.Courses.Find(id);
        public IEnumerable<Course> GetAllCourses() => _context.Courses.ToList();

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
        }

        public void UpdateCourse(Course course)
        {
            var existingCourse = GetCourseById(course.Id);
            if(existingCourse != null)
            {
                existingCourse.Title = course.Title;
                existingCourse.Description = course.Description;
                existingCourse.InstructorId = course.InstructorId;
                _context.SaveChanges();
            }
        }

        public void DeleteCourse(int id)
        {
            var existingCourse = GetCourseById(id);
            if(existingCourse != null)
            {
                _context.Courses.Remove(existingCourse);
                _context.SaveChanges();
            }
        }
    }
}
