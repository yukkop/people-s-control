using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IDraftReportQuery
    {
        public List<DraftReportDTO> Get(long id);
        public List<DraftReportDTO> GetAll();
    }
}
