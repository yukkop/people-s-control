using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IReportByProblemCategotyRepository
    {
        public ReportByProblemCategory Get(int id);
        public List<ReportByProblemCategory> GetAll();
        public ReportByProblemCategory Add(ReportByProblemCategory reportByProblemCategory);
    }
}
