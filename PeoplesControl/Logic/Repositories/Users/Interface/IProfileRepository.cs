using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IProfileRepository
    {
        public UserProfile Get(int id);
        public List<UserProfile> GetAll();
        public UserProfile Add(UserProfile userProfile);
    }
}
