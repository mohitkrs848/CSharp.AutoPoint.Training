using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using CSharp.AutoPoint.Training.Utilities;
using Serilog;
using System;

namespace CSharp.AutoPoint.Training.Agents
{
    public class EnrollmentOperations
    {
        private readonly Helper helperUtilities = new Helper();
        Logger logger = new Logger();

        internal void CreateEnrollment(IEnrollmentService enrollmentService)
        {
            Console.Clear();
            var enrollment = new Enrollment
            {
                CourseId = helperUtilities.ReadIntInput("Enter Course ID: "),
                StudentId = helperUtilities.ReadIntInput("Enter Student ID: ")
            };
            try
            {
                enrollmentService.CreateEnrollment(enrollment);
                logger.LogInformation("Enrollment created successfully. Press any key to continue...");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error creating Enrollment: {ex.Message}");
            }
            Console.ReadKey();
        }

        internal void DeleteEnrollment(IEnrollmentService enrollmentService)
        {
            var id = helperUtilities.ReadIntInput("Enter Enrollment ID to delete: ");
            try
            {
                enrollmentService.DeleteEnrollment(id);
                logger.LogInformation("Enrollment deleted successfully. Press any key to continue...");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error deleting Enrollment: {ex.Message}");
            }
            Console.ReadKey();
        }

        internal void DisplayAllEnrollments(IEnrollmentService enrollmentService)
        {
            Console.Clear();
            Console.WriteLine("Enrollments:");
            foreach (var enrollment in enrollmentService.GetAllEnrollments())
            {
                Console.WriteLine($"ID: {enrollment.Id}, Course ID: {enrollment.CourseId}, Student ID: {enrollment.StudentId}");
            }
            Console.ReadKey();
        }

        internal void GetEnrollment(IEnrollmentService enrollmentService)
        {
            var id = helperUtilities.ReadIntInput("Enter Enrollment ID to retrieve: ");
            var enrollment = enrollmentService.GetEnrollmentById(id);
            if (enrollment != null)
            {
                Console.WriteLine($"ID: {enrollment.Id}, Course ID: {enrollment.CourseId}, Student ID: {enrollment.StudentId}");
            }
            else
            {
                Console.WriteLine("Enrollment not found.");
            }
            Console.ReadKey();
        }

        internal void UpdateEnrollment(IEnrollmentService enrollmentService)
        {
            var id = helperUtilities.ReadIntInput("Enter Enrollment ID to update: ");
            var enrollment = enrollmentService.GetEnrollmentById(id);
            if (enrollment != null)
            {
                enrollment.CourseId = helperUtilities.ReadIntInput("Enter Course ID: ");
                enrollment.StudentId = helperUtilities.ReadIntInput("Enter Student ID: ");
                try
                {
                    enrollmentService.UpdateEnrollment(enrollment);
                    logger.LogInformation("Enrollment updated successfully. Press any key to continue...");
                }
                catch (Exception ex)
                {
                    logger.LogError($"Error updating Enrollment: {ex.Message}");
                }
            }
            else
            {
                logger.LogError("Enrollment not found.");
            }
            Console.ReadKey();
        }
    }
}
