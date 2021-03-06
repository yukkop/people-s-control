using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IReportWriteService
    {
        public RequestStatus Create(CreateReportDTO createEntity, long userId);
        public bool Update(UpdateReportDTO updateEntity);
        public void Delete(long id);
    }
}
