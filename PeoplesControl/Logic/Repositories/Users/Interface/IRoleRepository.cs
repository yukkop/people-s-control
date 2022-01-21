using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IRoleRepository
    {
        public Role Add(Role entity);
        public Role Get(long id);
        public List<Role> GetAll();
        public bool Update(Role entity);
        public void Delete(long id);
        public void SaveChanges();
    }
}
