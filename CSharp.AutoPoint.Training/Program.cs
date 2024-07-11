using CSharp.AutoPoint.Training.DependencyInjection;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using CSharp.AutoPoint.Training.Utilities;
using System;
using Unity;

namespace CSharp.AutoPoint.Training
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Unity container
            var container = UnityConfig.RegisterComponents();

            // Resolve services
            var userService = container.Resolve<IUserService>();
            var courseService = container.Resolve<ICourseService>();
            var enrollmentService = container.Resolve<IEnrollmentService>();

            // Create users
            User student = new User { Id = 1, Name = "Alice", Email = "alice@example.com", Role = "Student" };
            User instructor = new User { Id = 2, Name = "Bob", Email = "bob@example.com", Role = "Instructor" };

            userService.CreateUser(student);
            userService.CreateUser(instructor);

            // Create a course
            Course course = new Course { Id = 1, Title = "C# Basics", Description = "Introduction to C#", InstructorId = instructor.Id };
            courseService.CreateCourse(course);

            // Enroll student in the course
            Enrollment enrollment = new Enrollment { Id = 1, CourseId = course.Id, StudentId = student.Id };
            enrollmentService.CreateEnrollment(enrollment);

            // Display all users
            Logger.Log("Users:");
            foreach (var user in userService.GetAllUsers())
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Role: {user.Role}");
            }

            // Display all courses
            Logger.Log("Courses:");
            foreach (var c in courseService.GetAllCourses())
            {
                Console.WriteLine($"ID: {c.Id}, Title: {c.Title}, Description: {c.Description}, Instructor ID: {c.InstructorId}");
            }

            // Display all enrollments
            Logger.Log("Enrollments:");
            foreach (var e in enrollmentService.GetAllEnrollments())
            {
                Console.WriteLine($"ID: {e.Id}, Course ID: {e.CourseId}, Student ID: {e.StudentId}");
            }

            Console.ReadKey();
        }
    }
}
