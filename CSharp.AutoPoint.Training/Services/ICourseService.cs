using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Interfaces
{
    public interface ICourseService
    {
        void CreateCourse(Course course);
        Course GetCourseById(int id);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        IEnumerable<Course> GetAllCourses();
    }
}
