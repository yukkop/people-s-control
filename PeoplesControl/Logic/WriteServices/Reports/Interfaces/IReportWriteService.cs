using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IReportWriteService
    {
        public ActionStatus<GetReportDTO> Add(CreateReportDTO createEntity);
        public bool Update(UpdateReportDTO updateEntity);
        public void Delete(long id);
    }
}
