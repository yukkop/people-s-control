using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IDraftReportRepository
    {
        public DraftReport Get(int id);
        public List<DraftReport> GetAll();
        public DraftReport Add(DraftReport draftReport);
    }
}
