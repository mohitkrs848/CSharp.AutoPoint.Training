using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Services
{
    internal class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Course GetCourseById(int id) => _courseRepository.GetCourseById(id);

        public IEnumerable<Course> GetAllCourses() => _courseRepository.GetAllCourses();

        public void CreateCourse(Course course) => _courseRepository.AddCourse(course);

        public void UpdateCourse(Course course) => _courseRepository.UpdateCourse(course);

        public void DeleteCourse(int id) => _courseRepository.DeleteCourse(id);
    }
}
