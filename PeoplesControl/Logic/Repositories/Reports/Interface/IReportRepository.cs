using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IReportRepository
    {
        public Report Get(long id);
        public List<Report> GetAll();
        public Report Add(Report report);
        public bool Update(Report report);
        public void Delete(long id);
        public void SaveChanges();
    }
}
