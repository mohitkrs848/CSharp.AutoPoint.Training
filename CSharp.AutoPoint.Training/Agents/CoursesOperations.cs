using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using CSharp.AutoPoint.Training.Services;
using CSharp.AutoPoint.Training.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Agents
{
    public class CoursesOperations
    {
        private Helper helperUtilities = new Helper();
        Logger logger = new Logger();

        internal void CreateCourse(ICourseService courseService)
        {
            Console.Clear();
            var course = new Course
            {
                Title = helperUtilities.ReadInput("Enter Course Title: "),
                Description = helperUtilities.ReadInput("Enter Course Description: ")
            };
            try
            {
                courseService.CreateCourse(course);
                logger.LogInformation("Course created successfully. Press any key to continue...");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error creating Course: {ex.Message}");
            }
            Console.ReadKey();
        }

        internal void DeleteCourse(ICourseService courseService)
        {
            var id = helperUtilities.ReadIntInput("Enter Course ID to delete: ");
            try
            {
                courseService.DeleteCourse(id);
                logger.LogInformation("Course deleted successfully. Press any key to continue...");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error deleting Course: {ex.Message}");
            }
            Console.ReadKey();
        }

        internal void DisplayAllCourses(ICourseService courseService)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Courses:");
                foreach (var course in courseService.GetAllCourses())
                {
                    Console.WriteLine($"ID: {course.Id}, Title: {course.Title}, Description: {course.Description}");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error displaying all the courses: {ex.Message}");
            }
        }

        internal void GetCourse(ICourseService courseService)
        {
            var id = helperUtilities.ReadIntInput("Enter Course ID to retrieve: ");
            var course = courseService.GetCourseById(id);
            if (course != null)
            {
                Console.WriteLine($"ID: {course.Id}, Title: {course.Title}, Description: {course.Description}");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
            Console.ReadKey();
        }

        internal void UpdateCourse(ICourseService courseService)
        {
            var id = helperUtilities.ReadIntInput("Enter Course ID to update: ");
            var course = courseService.GetCourseById(id);
            if (course != null)
            {
                course.Title = helperUtilities.ReadInput("Enter Course Title: ");
                course.Description = helperUtilities.ReadInput("Enter Course Description: ");
                try
                {
                    courseService.UpdateCourse(course);
                    logger.LogInformation("Course updated successfully. Press any key to continue...");
                }
                catch (Exception ex)
                {
                    logger.LogError($"Error updating Course: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
            Console.ReadKey();
        }
    }
}
