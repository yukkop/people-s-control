using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IDraftReportQuery
    {
        public DraftReportDTO Get(long id);
        public List<DraftReportDTO> GetAllByUserId(long userId);
        public List<DraftReportDTO> GetAll();
    }
}
