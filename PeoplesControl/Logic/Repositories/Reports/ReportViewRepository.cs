using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public class ReportViewRepository : IReportViewRepository
    {
        IWebContext _context;
        public ReportViewRepository(IWebContext context)
        {
            _context = context;
        }

        public ReportView Add(ReportView entity)
        {
            return _context.ReportsViews.Add(entity).Entity;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
