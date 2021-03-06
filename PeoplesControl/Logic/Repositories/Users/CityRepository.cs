using DataBase.Models;
using DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic.Repositories
{
    public class CityRepository: ICityRepository
    {
        IWebContext _context;
        public CityRepository(IWebContext context)
        {
            _context = context;
        }

        public City Add(City entity)
        {
            return _context.Cities.Add(entity).Entity;
        }

        public City Get(long id)
        {
            return _context.Cities.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public bool Update(City entity)
        {
            return _context.Update(entity);
        }
        public Exception Delete(long id)
        {
            try
            {
                _context.Cities.Remove(_context.Cities.Where(i => i.Id == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                return e;
            }
            return null;
        }
        public Exception SaveChanges()
        {
           return _context.SaveChanges();
        }
    }
}
