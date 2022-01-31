using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IReportStatusReadService
    {
        public RequestStatus<GetReportStatusDTO> Get(long id);
        public RequestStatus<List<GetReportStatusDTO>> GetAll();
    }
}
