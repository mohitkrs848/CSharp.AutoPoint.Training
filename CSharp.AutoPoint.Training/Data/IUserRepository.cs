﻿using CSharp.AutoPoint.Training.Models;
using System.Collections.Generic;

namespace CSharp.AutoPoint.Training.Data
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

    }
}
