using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IUserRepository
    {
        public User Get(int id);
        public List<User> GetAll();
        public User Add(User user);
    }
}
