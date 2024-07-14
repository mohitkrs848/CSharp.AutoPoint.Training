using CSharp.AutoPoint.Training.Data;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.AutoPoint.Training.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly LMSDbContext _context;

        public UserRepository(LMSDbContext context)
        {
            _context = context;
        }
        public User GetUserById(int id) => _context.Users.Find(id);

        public IEnumerable<User> GetAllUsers() => _context.Users.ToList();

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
