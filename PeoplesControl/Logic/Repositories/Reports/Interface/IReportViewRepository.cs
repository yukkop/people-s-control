using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IReportViewRepository
    {
        public ReportView Add(ReportView reportView);
        public void SaveChanges();
    }
}
