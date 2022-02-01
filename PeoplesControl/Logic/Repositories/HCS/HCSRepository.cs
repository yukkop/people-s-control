using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories 
{
    public class HCSRepository : IHCSRepository
    {
        IWebContext _context;
        public HCSRepository(IWebContext context)
        {
            _context = context;
        }
        public HCS Add(HCS hcs)
        {
            return _context.HCSs.Add(hcs).Entity;
        }

        public HCS Get(long id)
        {
            return _context.HCSs.Where(i => i.Id == id).FirstOrDefault();
        }

        public List<HCS> GetAll()
        {
            return _context.HCSs.ToList();
        }

        public Exception SaveChanges()
        {
            return _context.SaveChanges();
        }

        public bool Update(HCS entity)
        {
            return _context.Update(entity);
        }
    }
}
