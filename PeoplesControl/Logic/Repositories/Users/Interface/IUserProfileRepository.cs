using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IUserProfileRepository
    {
        public UserProfile Get(long id);
        public List<UserProfile> GetAll();
        public UserProfile Add(UserProfile userProfile);
        bool Update(UserProfile entity);
        void SaveChanges();
        void Delete(long id);
    }
}
