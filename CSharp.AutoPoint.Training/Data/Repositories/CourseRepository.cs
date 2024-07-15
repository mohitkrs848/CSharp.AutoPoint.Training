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
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(LMSDbContext context) : base(context)
        {
        }

        public Course GetCourseById(int id) => GetById(id);

        public IEnumerable<Course> GetAllCourses() => GetAll();

        public void AddCourse(Course course) => Add(course);

        public void UpdateCourse(Course course) => Update(course);

        public void DeleteCourse(int id) => Delete(GetById(id));
    }
}
