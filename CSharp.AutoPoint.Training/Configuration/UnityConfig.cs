using CSharp.AutoPoint.Training.Data;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Repositories;
using CSharp.AutoPoint.Training.Services;
using CSharp.AutoPoint.Training.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CSharp.AutoPoint.Training.DependencyInjection
{
    public static class UnityConfig
    {
        public static IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            // Register all your components with the container here
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICourseRepository, CourseRepository>();
            container.RegisterType<IEnrollmentRepository, EnrollmentRepository>();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<IEnrollmentService, EnrollmentService>();

            return container;
        }
    }
}
