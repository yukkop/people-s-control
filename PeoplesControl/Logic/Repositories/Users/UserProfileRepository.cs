using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        IWebContext _context;
        public UserProfileRepository(IWebContext context)
        {
            _context = context;
        }

        public UserProfile Add(UserProfile entity)
        {
            return _context.UsersProfiles.Add(entity).Entity;
        }

        public UserProfile Get(long id)
        {
            return _context.UsersProfiles.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<UserProfile> GetAll()
        {
            return _context.UsersProfiles.ToList();
        }

        public bool Update(UserProfile entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.UsersProfiles.Remove(_context.UsersProfiles.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
