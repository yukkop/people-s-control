using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IReportStatusReadService
    {
        public ActionStatus<GetReportStatusDTO> Get(long id);
        public ActionStatus<List<GetReportStatusDTO>> GetAll();
    }
}
