using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class AvatarRepository : IAvatarRepository
    {
        IWebContext _context;
        public AvatarRepository(IWebContext context)
        {
            _context = context;
        }

        public Avatar Add(Avatar entity)
        {
            return _context.Avatars.Add(entity).Entity;
        }

        public Avatar Get(long id)
        {
            return _context.Avatars.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<Avatar> GetAll()
        {
            return _context.Avatars.ToList();
        }

        public bool Update(Avatar entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.Avatars.Remove(_context.Avatars.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
