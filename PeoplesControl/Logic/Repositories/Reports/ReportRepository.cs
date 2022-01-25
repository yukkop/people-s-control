using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class ReportRepository : IReportRepository
    {
        IWebContext _context;
        public ReportRepository(IWebContext context)
        {
            _context = context;
        }

        public Report Add(Report entity)
        {
            return _context.Reports.Add(entity).Entity;
        }

        public Report Get(long id)
        {
            return _context.Reports.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<Report> GetAll()
        {
            return _context.Reports.ToList();
        }

        public bool Update(Report entity)
        {
            return _context.Update(entity);

        }
        public void Delete(long id)
        {
            _context.Reports.Remove(_context.Reports.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
