using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        IEnumerable<Enrollment> GetAllEnrollments(int id);
        Task<int> CountStudentsAsync();
        Task<int> CountInstructorAsync();
    }
}
