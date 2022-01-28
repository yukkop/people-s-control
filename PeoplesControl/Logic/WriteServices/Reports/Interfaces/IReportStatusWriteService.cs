using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IReportStatusWriteService
    {
        public RequestStatus<GetReportStatusDTO> Add(CreateReportStatusDTO createEntity);
        public bool Update(UpdateReportStatusDTO updateEntity);
        public void Delete(long id);
    }
}
