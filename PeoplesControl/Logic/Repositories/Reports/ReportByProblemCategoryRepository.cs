using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class ReportByProblemCategoryRepository : IReportByProblemCategoryRepository
    {
        IWebContext _context;
        public ReportByProblemCategoryRepository(IWebContext context)
        {
            _context = context;
        }
        public ReportByProblemCategory Add(ReportByProblemCategory reportByProblemCategory)
        {
            return _context.ReportsByProblemCategories.Add(reportByProblemCategory).Entity;
        }

        public void Delete(ReportByProblemCategory entity)
        {
            _context.ReportsByProblemCategories.Remove(_context.ReportsByProblemCategories.
                        Where(i => i.ReportId == entity.ReportId && i.ProblemCategoryId == entity.ProblemCategoryId).FirstOrDefault());
        }

        public Exception SaveChanges()
        {
            return _context.SaveChanges();
        }
        public ReportByProblemCategory Get(long id)
        {
            return _context.ReportsByProblemCategories.Where(entity => entity.Id == id).FirstOrDefault();
        }
    }
}
