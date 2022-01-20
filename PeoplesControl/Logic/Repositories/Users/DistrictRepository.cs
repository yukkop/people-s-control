using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class DistrictRepository : IDistrictRepository
    {
        IWebContext _context;
        public DistrictRepository(IWebContext context)
        {
            _context = context;
        }

        public District Add(District entity)
        {
            return _context.Districts.Add(entity).Entity;
        }

        public District Get(long id)
        {
            return _context.Districts.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<District> GetAll()
        {
            return _context.Districts.ToList();
        }

        public bool Update(District entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.Districts.Remove(_context.Districts.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
