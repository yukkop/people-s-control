using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IUserRoleRepository
    {
        public UserRole Get(int id);
        public List<UserRole> GetAll();
        public UserRole Add(UserRole userRole);
    }
}
