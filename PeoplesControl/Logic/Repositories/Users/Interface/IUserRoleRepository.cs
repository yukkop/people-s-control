using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IUserRoleRepository
    {
        public UserRole Get(long id);
        public List<UserRole> GetAll();
        public UserRole Add(UserRole UserRole);
        bool Update(UserRole entity);
        Exception SaveChanges();
        void Delete(long id);
    }
}
