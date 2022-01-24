using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IReportStatusQuery
    {
        public ReportStatusDTO Get(long id);
        public List<ReportStatusDTO> GetAll();
    }
}
