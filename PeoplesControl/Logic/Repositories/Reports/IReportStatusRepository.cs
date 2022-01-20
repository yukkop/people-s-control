using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IReportStatusRepository
    {
        public ReportStatus Get(int id);
        public List<ReportStatus> GetAll();
        public ReportStatus Add(ReportStatus reportStatus);
    }
}
