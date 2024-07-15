using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id) => _userRepository.GetUserById(id);

        public IEnumerable<User> GetAllUsers() => _userRepository.GetAllUsers();

        public void CreateUser(User user) => _userRepository.AddUser(user);

        public void UpdateUser(User user) => _userRepository.UpdateUser(user);

        public void DeleteUser(int id) => _userRepository.DeleteUser(id);

        public IEnumerable<Enrollment> GetAllEnrollments(int id)
        {
            var user = _userRepository.GetUserById(id);
            return user.Enrollments;
        }
    }
}
