using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        IWebContext _context;

        public RoleRepository(IWebContext context)
        {
            _context = context;
        }

        public Role Add(Role entity)
        {
            return _context.Roles.Add(entity).Entity;
        }

        public Role Get(long id)
        {
            return _context.Roles.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();
        }

        public bool Update(Role entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.Roles.Remove(_context.Roles.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
