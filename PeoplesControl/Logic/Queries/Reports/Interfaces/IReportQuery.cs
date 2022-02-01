using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IReportQuery
    {
        public ReportDTO Get(long id);
        public List<ShortShowReportDTO> GetPage(RequestReportsPageDTO pageSettings);
        public List<ShortShowReportDTO> GetPageNearbyReports(RequerstNearbyReportsPageDTO pageSettings);
    }
}
