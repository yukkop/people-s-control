using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IDraftReportRepository
    {
        public DraftReport Get(long id);
        public List<DraftReport> GetAll();
        public DraftReport Add(DraftReport draftReport);
        public Exception SaveChanges();
        public bool Update(DraftReport entity);
    }
}
