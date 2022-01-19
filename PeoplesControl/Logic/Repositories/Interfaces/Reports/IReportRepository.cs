using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    interface IReportRepository
    {
        public Report Get(int id);
        public List<Report> GetAll();
        public Report Add(Report report);
    }
}
