using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IDraftReportByProblemCategoryRepository
    {
        public DraftReportByProblemCategory Get(int id);
        public List<DraftReportByProblemCategory> GetAll();
        public DraftReportByProblemCategory Add(DraftReportByProblemCategory draftReportByProblemCategory);
    }
}
