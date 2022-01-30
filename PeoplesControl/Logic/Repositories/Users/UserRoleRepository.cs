using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class UserRoleRepository: IUserRoleRepository
    {
        IWebContext _context;

        public UserRoleRepository(IWebContext context)
        {
            _context = context;
        }

        public UserRole Add(UserRole entity)
        {
            return _context.UsersRoles.Add(entity).Entity;
        }

        public UserRole Get(long id)
        {
            return _context.UsersRoles.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<UserRole> GetAll()
        {
            return _context.UsersRoles.ToList();
        }

        public bool Update(UserRole entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.UsersRoles.Remove(_context.UsersRoles.Where(i => i.Id == id).FirstOrDefault());
        }
        public Exception SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
