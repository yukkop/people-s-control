using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{ 
    public interface IDraftReportReadService
    {
        public RequestStatus<GetDraftReportDTO> Get(long id);
        public RequestStatus<List<GetDraftReportDTO>> GetAllByUserId(long userId);
        public RequestStatus<List<GetDraftReportDTO>> GetAll();
    }
}
