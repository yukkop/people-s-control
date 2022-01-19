using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IProfileRepository
    {
        public Profile Get(int id);
        public List<Profile> GetAll();
        public Profile Add(Profile profile);
    }
}
