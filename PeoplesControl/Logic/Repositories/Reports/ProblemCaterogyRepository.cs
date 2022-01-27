using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class ProblemCategoryRepository : IProblemCategoryRepository
    {
        IWebContext _context;
        public ProblemCategoryRepository(IWebContext context)
        {
            _context = context;
        }

        public ProblemCategory Add(ProblemCategory entity)
        {
            return _context.ProblemCategories.Add(entity).Entity;
        }

        public ProblemCategory Get(long id)
        {
            return _context.ProblemCategories.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<ProblemCategory> GetAll()
        {
            return _context.ProblemCategories.ToList();
        }

        public bool Update(ProblemCategory entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.ProblemCategories.Remove(_context.ProblemCategories.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
