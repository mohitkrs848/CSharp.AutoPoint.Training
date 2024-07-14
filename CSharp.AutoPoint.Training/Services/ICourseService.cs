using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Interfaces
{
    internal interface ICourseService
    {
        Course GetCourseById(int id);
        IEnumerable<Course> GetAllCourses();
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
