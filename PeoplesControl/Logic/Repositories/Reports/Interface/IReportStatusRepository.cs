using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IReportStatusRepository
    {
        public ReportStatus Get(long id);
        public List<ReportStatus> GetAll();
        public ReportStatus Add(ReportStatus entity);
        bool Update(ReportStatus entity);
        void SaveChanges();
        void Delete(long id);
    }
}
