using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class UserRepository : IUserRepository
    {
        IWebContext _context;
        public UserRepository(IWebContext context)
        {
            _context = context;
        }

        public User Add(User entity)
        {
            return _context.Users.Add(entity).Entity;
        }

        public User Get(long id)
        {
            return _context.Users.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public bool Update(User entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.Users.Remove(_context.Users.Where(i => i.Id == id).FirstOrDefault());
        }
        public Exception SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
