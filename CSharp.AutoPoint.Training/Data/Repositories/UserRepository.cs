using CSharp.AutoPoint.Training.Data;
using CSharp.AutoPoint.Training.Interfaces;
using CSharp.AutoPoint.Training.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CSharp.AutoPoint.Training.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LMSDbContext context) : base(context)
        {
        }
        public User GetUserById(int id) => GetById(id);

        public IEnumerable<User> GetAllUsers() => GetAll();

        public void AddUser(User user) => Add(user);
        public void UpdateUser(User user) => Update(user);

        public void DeleteUser(int id) => Delete(GetById(id));

        public async Task<int> CountUsersByRoleAsync(UserRole role)
        {
            return await _context.Users.CountAsync(u => u.Role == role.ToString());
        }
    }
}