using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class DraftReportRepository : IDraftReportRepository
    {
        IWebContext _context;
        public DraftReportRepository(IWebContext context)
        {
            _context = context;
        }
        public DraftReport Add(DraftReport draftReport)
        {
            return _context.DraftReports.Add(draftReport).Entity;
        }

        public DraftReport Get(long id)
        {
            return _context.DraftReports.Where(i => i.Id == id).FirstOrDefault();
        }

        public List<DraftReport> GetAll()
        {
            return _context.DraftReports.ToList();
        }

        public Exception SaveChanges()
        {
            return _context.SaveChanges();
        }

        public bool Update(DraftReport entity)
        {
            return _context.Update(entity);

        }
    }
}
