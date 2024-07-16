using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using CSharp.AutoPoint.Training.Services;
using CSharp.AutoPoint.Training.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;
using static CSharp.AutoPoint.Training.Models.User;

namespace CSharp.AutoPoint.Training.Agents
{
    public class UsersOperations
    {
        private Helper helperUtilities = new Helper();
        Logger logger = new Logger();

        /// <summary>
        /// Creating a new user in the User Table with Name, Email and Role
        /// </summary>
        /// <param name="userService">Parameter of type IUserInterface for referencing the methods initialized in the interface</param>
        internal void CreateUser(IUserService userService)
        {
            Console.Clear();
            User user = new User();
            user.Name = helperUtilities.ReadInput("Enter Name: ");
            user.Email = helperUtilities.ReadInput("Enter Email: ");

            while (true)
            {
                user.Role = helperUtilities.ReadInput("Enter Role (S for Student/I for Instructor): ").ToUpper();
                if (user.Role == "S")
                {
                    user.Role = UserRole.Student.ToString();
                    break;
                }
                else if(user.Role == "I")
                {
                    user.Role = UserRole.Instructor.ToString();
                    break;
                }
                else
                {
                    logger.LogWarning("Invalid role. Please enter 'S' for Student or 'I' for Instructor.");
                }
            }

            try
            {
                userService.CreateUser(user);
                logger.LogInformation("User created successfully. Press any key to continue...");
            }

            catch (Exception ex)
            {
                logger.LogError($"Error creating user: {ex.Message}");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Deleting a user from the database using the User id
        /// </summary>
        /// <param name="userService">Parameter of type IUserInterface for referencing the methods initialized in the interface<</param>
        internal void DeleteUser(IUserService userService)
        {
            Console.Clear();
            var id = helperUtilities.ReadIntInput("Enter User ID to delete: ");

            try
            {
                userService.DeleteUser(id);
                logger.LogInformation("User deleted successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error deleting user: {ex.Message}");
            }

            Console.ReadKey();
        }

        internal void DisplayAllUsers(IUserService userService)
        {
            Console.Clear();
            Console.WriteLine("Users:");

            try
            {
                var users = userService.GetAllUsers();
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Role: {user.Role}");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error fetching users: {ex.Message}");
            }

            Console.ReadKey();
        }

        internal void FindEnrollments(IUserService userService)
        {
            var userid = helperUtilities.ReadIntInput("Enter User ID to find enrollments: ");
            var enrollments = userService.GetAllEnrollments(userid);
            if (enrollments != null)
            {
                Console.WriteLine($"Enrollments for {userid} :");
                foreach (var enrollment in enrollments)
                {
                    Console.WriteLine($"ID: {enrollment.Id}, Course ID: {enrollment.CourseId}, Student ID: {enrollment.StudentId}");
                }
            }
            else
            {
                logger.LogError("No enrollments found.");
            }
            Console.ReadKey();
        }

        internal void GetUser(IUserService userService)
        {
            Console.Clear();
            var id = helperUtilities.ReadIntInput("Enter User ID to retrieve: ");

            try
            {
                var user = userService.GetUserById(id);
                if (user != null)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Role: {user.Role}");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error fetching user: {ex.Message}");
            }

            Console.ReadKey();
        }

        internal void UpdateUser(IUserService userService)
        {
            Console.Clear();
            var id = helperUtilities.ReadIntInput("Enter User ID to update: ");

            try
            {
                var user = userService.GetUserById(id);
                if (user != null)
                {
                    user.Name = helperUtilities.ReadInput("Enter Name: ");
                    user.Email = helperUtilities.ReadInput("Enter Email: ");
                    user.Role = helperUtilities.ReadInput("Enter Role: ");

                    userService.UpdateUser(user);
                    Console.WriteLine("User updated successfully. Press any key to continue...");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error updating user: {ex.Message}");
            }

            Console.ReadKey();
        }

        internal async Task CountUsers(IUserService userService)
        {
            Console.Clear();
            CountUsers countStudent = userService.CountStudentsAsync;
            CountUsers countInstructor = userService.CountInstructorAsync;

            logger.LogInformation($"Total Students: {await ExecuteCountUsersAsync(countStudent)}");
            logger.LogInformation($"Total Instructors: {await ExecuteCountUsersAsync(countInstructor)}");
            Console.ReadKey();
        }

        public async Task<int> ExecuteCountUsersAsync(CountUsers countUsers)
        {
            return await countUsers();
        }
    }
}
