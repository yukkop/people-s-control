using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IReportReadService
    {
        public RequestStatus<GetReportDTO> Get(long id);
        public RequestStatus<List<ShortShowReportDTO>> GetPage(RequestReportsPageDTO pageSettings);
    }
}
