using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class ReportStatusRepository : IReportStatusRepository
    {
        IWebContext _context;
        public ReportStatusRepository(IWebContext context)
        {
            _context = context;
        }

        public ReportStatus Add(ReportStatus entity)
        {
            return _context.ReportStatuses.Add(entity).Entity;
        }

        public ReportStatus Get(long id)
        {
            return _context.ReportStatuses.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<ReportStatus> GetAll()
        {
            return _context.ReportStatuses.ToList();
        }

        public bool Update(ReportStatus entity)
        {
            return _context.Update(entity);
        }
        public void Delete(long id)
        {
            _context.ReportStatuses.Remove(_context.ReportStatuses.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
