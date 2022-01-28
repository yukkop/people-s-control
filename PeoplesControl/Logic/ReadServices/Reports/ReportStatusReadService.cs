using AutoMapper;
using Logic.Helpers;
using Logic.Profiles;
using Logic.Queries;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public class ReportStatusReadService : IReportStatusReadService
    {
        IReportStatusQuery _reportStatusQuery;
        private readonly IMapper _mapper;
        public ReportStatusReadService(IReportStatusQuery reportStatusQuery, IMapper mapper)
        {
            _reportStatusQuery = reportStatusQuery;
            _mapper = mapper;
        }

        public RequestStatus<GetReportStatusDTO> Get(long id)
        {
            ReportStatusDTO entity = _reportStatusQuery.Get(id);
            return new RequestStatus<GetReportStatusDTO>(_mapper.Map<GetReportStatusDTO>(entity));
        }
        public RequestStatus<List<GetReportStatusDTO>> GetAll()
        {
            List<ReportStatusDTO> entities = _reportStatusQuery.GetAll();
            List<GetReportStatusDTO> getEntities = new List<GetReportStatusDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetReportStatusDTO>(entity));
            }

            return new RequestStatus<List<GetReportStatusDTO>>(getEntities);
        }
    }
}

