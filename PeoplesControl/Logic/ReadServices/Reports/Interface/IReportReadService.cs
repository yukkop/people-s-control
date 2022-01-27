using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IReportReadService
    {
        public ActionStatus<GetReportDTO> Get(long id);
        public ActionStatus<List<GetReportDTO>> GetPage(RequestReportsPageDTO pageSettings);
    }
}
