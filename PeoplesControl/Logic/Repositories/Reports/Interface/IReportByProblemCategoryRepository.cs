using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IReportByProblemCategoryRepository
    {
        public ReportByProblemCategory Add(ReportByProblemCategory reportByProblemCategory);
        Exception SaveChanges();
        public void Delete(ReportByProblemCategory entity);
        public ReportByProblemCategory Get(long id);
    }
}
