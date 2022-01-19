using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IReportViewRepository
    {
        public ReportView Get(int id);
        public List<ReportView> GetAll();
        public ReportView Add(ReportView reportView);
    }
}
