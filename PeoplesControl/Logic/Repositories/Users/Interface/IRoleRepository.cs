using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IRoleRepository
    {
        public Role Get(int id);
        public List<Role> GetAll();
        public Role Add(Role role);
    }
}
