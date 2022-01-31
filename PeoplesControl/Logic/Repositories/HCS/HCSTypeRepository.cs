using DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Models;
using System.Linq;

namespace Logic.Repositories
{
    public class HCSTypeRepository : IHCSTypeRepository
    {
        IWebContext _context;
        public HCSTypeRepository(IWebContext context)
        {
            _context = context;
        }
        public HCSType Add(HCSType hcs)
        {
            return _context.HCSTypes.Add(hcs).Entity;
        }

        public HCSType Get(long id)
        {
            return _context.HCSTypes.Where(i => i.Id == id).FirstOrDefault();
        }

        public List<HCSType> GetAll()
        {
            return _context.HCSTypes.ToList();
        }

        public Exception SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Delete(long id)
        {
            _context.HCSTypes.Remove(_context.HCSTypes.Where(i => i.Id == id).FirstOrDefault());
        }
        public bool Update(HCSType entity)
        {
            return _context.Update(entity);
        }
    }
}
