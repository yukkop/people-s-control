using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IReportQuery
    {
        public ReportDTO Get(long id);
        public List<ReportDTO> GetPage(RequestReportsPageDTO pageSettings);
    }
}
