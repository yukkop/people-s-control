using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        IWebContext _context;
        public RegionRepository(IWebContext context)
        {
            _context = context;
        }

        public Region Add(Region entity)
        {
            return _context.Regions.Add(entity).Entity;
        }

        public Region Get(long id)
        {
            return _context.Regions.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<Region> GetAll()
        {
            return _context.Regions.ToList();
        }

        public bool Update(Region entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.Regions.Remove(_context.Regions.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
