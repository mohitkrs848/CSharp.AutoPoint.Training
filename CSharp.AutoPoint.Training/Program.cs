using CSharp.AutoPoint.Training.Agents;
using CSharp.AutoPoint.Training.DependencyInjection;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using CSharp.AutoPoint.Training.Services;
using CSharp.AutoPoint.Training.Utilities;
using Serilog;
using System;
using Unity;

namespace CSharp.AutoPoint.Training
{
    class Program
    {
        public static UsersOperations usersOperations = new UsersOperations();
        public static CoursesOperations courseOperations = new CoursesOperations();
        public static EnrollmentOperations enrollmentOperations = new EnrollmentOperations();
        public static Logger logger = new Logger();

        static void Main(string[] args)
        {
            ApplicationEvent.StartApplication += OnStartApplication;
            Console.WriteLine("Press '1' to start the application.");
            var input = Console.ReadLine();

            if (input == "1")
            {
                ApplicationEvent.OnStartApplication();
            }
            else
            {
                Console.WriteLine("Invalid input. Exiting...");
            }
        }

        private static void OnStartApplication(object sender, EventArgs e)
        {
            logger.LogInformation("LMS Application Started......");
            MainMenu();
        }

        private static void MainMenu()
        {
            // Setup Unity container
            var container = UnityConfig.RegisterComponents();

            // Resolve services
            var userService = container.Resolve<IUserService>();
            var courseService = container.Resolve<ICourseService>();
            var enrollmentService = container.Resolve<IEnrollmentService>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to LMS Console Application");
                Console.WriteLine("1. User Section");
                Console.WriteLine("2. Course Section");
                Console.WriteLine("3. Enrollment Section");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Please select an option: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        UserSection(userService);
                        break;
                    case "2":
                        CourseSection(courseService);
                        break;
                    case "3":
                        EnrollmentSection(enrollmentService);
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        logger.LogError("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void UserSection(IUserService userService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User Section");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Get User");
                Console.WriteLine("3. Display All Users");
                Console.WriteLine("4. Update User");
                Console.WriteLine("5. Delete User");
                Console.WriteLine("6. Find Enrollments");
                Console.WriteLine("7. Count Users");
                Console.WriteLine("8. Go Back");
                Console.WriteLine("Please select an option: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        usersOperations.CreateUser(userService);
                        break;
                    case "2":
                        usersOperations.GetUser(userService);
                        break;
                    case "3":
                        usersOperations.DisplayAllUsers(userService);
                        break;
                    case "4":
                        usersOperations.UpdateUser(userService);
                        break;
                    case "5":
                        usersOperations.DeleteUser(userService);
                        break;
                    case "6":
                        usersOperations.FindEnrollments(userService);
                        break;
                    case "7":
                        _ = usersOperations.CountUsers(userService);
                        break;
                    case "8":
                        return;
                    default:
                        logger.LogError("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CourseSection(ICourseService courseService)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Course Section");
                Console.WriteLine("1. Create Course");
                Console.WriteLine("2. Get Course");
                Console.WriteLine("3. Display All Courses");
                Console.WriteLine("4. Update Course");
                Console.WriteLine("5. Delete Course");
                Console.WriteLine("6. Go Back");
                Console.WriteLine("Please select an option: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        courseOperations.CreateCourse(courseService);
                        break;
                    case "2":
                        courseOperations.GetCourse(courseService);
                        break;
                    case "3":
                        courseOperations.DisplayAllCourses(courseService);
                        break;
                    case "4":
                        courseOperations.UpdateCourse(courseService);
                        break;
                    case "5":
                        courseOperations.DeleteCourse(courseService);
                        break;
                    case "6":
                        return;
                    default:
                        logger.LogError("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void EnrollmentSection(IEnrollmentService enrollmentService)
        {
            Console.Clear();
            Console.WriteLine("Enrollment Section");
            Console.WriteLine("1. Create Enrollment");
            Console.WriteLine("2. Get Enrollment");
            Console.WriteLine("3. Display All Enrollments");
            Console.WriteLine("4. Update Enrollment");
            Console.WriteLine("5. Delete Enrollment");
            Console.WriteLine("6. Go Back");
            Console.WriteLine("Please select an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    enrollmentOperations.CreateEnrollment(enrollmentService);
                    break;
                case "2":
                    enrollmentOperations.GetEnrollment(enrollmentService);
                    break;
                case "3":
                    enrollmentOperations.DisplayAllEnrollments(enrollmentService);
                    break;
                case "4":
                    enrollmentOperations.UpdateEnrollment(enrollmentService);
                    break;
                case "5":
                    enrollmentOperations.DeleteEnrollment(enrollmentService);
                    break;
                case "6":
                    return;
                default:
                    logger.LogError("Invalid option. Please try again.");
                    Console.ReadKey();
                    break;
            }
        }





        //// Create users
        //User student = new User { Id = 1, Name = "Alice", Email = "alice@example.com", Role = "Student" };
        //User instructor = new User { Id = 2, Name = "Bob", Email = "bob@example.com", Role = "Instructor" };

        //userService.CreateUser(student);
        //userService.CreateUser(instructor);

        //// Create a course
        //Course course = new Course { Id = 1, Title = "C# Basics", Description = "Introduction to C#", InstructorId = instructor.Id };
        //courseService.CreateCourse(course);

        //// Enroll student in the course
        //Enrollment enrollment = new Enrollment { Id = 1, CourseId = course.Id, StudentId = student.Id };
        //enrollmentService.CreateEnrollment(enrollment);

        //// Display all users
        //Logger.Log("Users:");
        //foreach (var user in userService.GetAllUsers())
        //{
        //    Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Role: {user.Role}");
        //}

        //// Display all courses
        //Logger.Log("Courses:");
        //foreach (var c in courseService.GetAllCourses())
        //{
        //    Console.WriteLine($"ID: {c.Id}, Title: {c.Title}, Description: {c.Description}, Instructor ID: {c.InstructorId}");
        //}

        //// Display all enrollments
        //Logger.Log("Enrollments:");
        //foreach (var e in enrollmentService.GetAllEnrollments())
        //{
        //    Console.WriteLine($"ID: {e.Id}, Course ID: {e.CourseId}, Student ID: {e.StudentId}");
        //}

        //Console.ReadKey();
    }
}

