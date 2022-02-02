using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IDraftReportWriteService
    {
        public RequestStatus Create(CreateDraftReportDTO createEntity, long userId);
        public bool Update(UpdateDraftReportDTO updateEntity);
        public void Delete(long id);
    }
}
