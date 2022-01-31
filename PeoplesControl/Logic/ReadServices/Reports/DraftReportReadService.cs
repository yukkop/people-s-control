using AutoMapper;
using Logic.Helpers;
using Logic.Queries;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public class DraftReportReadService : IDraftReportReadService
    {
        IDraftReportQuery _draftReportQuery;
        private readonly IMapper _mapper;
        public DraftReportReadService(IDraftReportQuery draftReportQuery, IMapper mapper)
        {
            _draftReportQuery = draftReportQuery;
            _mapper = mapper;
        }
        public RequestStatus<List<GetDraftReportDTO>> Get(long userId)
        {
            List<DraftReportDTO> entities = _draftReportQuery.Get(userId);
            List<GetDraftReportDTO> getEntities = new List<GetDraftReportDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetDraftReportDTO>(entity));
            }

            return new RequestStatus<List<GetDraftReportDTO>>(getEntities);
        }

        public RequestStatus<List<GetDraftReportDTO>> GetAll()
        {
            List<DraftReportDTO> entities = _draftReportQuery.GetAll();
            List<GetDraftReportDTO> getEntities = new List<GetDraftReportDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetDraftReportDTO>(entity));
            }

            return new RequestStatus<List<GetDraftReportDTO>>(getEntities);
        }
    }
}
