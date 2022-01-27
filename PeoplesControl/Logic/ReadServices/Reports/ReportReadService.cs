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
    public class ReportReadService : IReportReadService
    {
        IReportQuery _reportQuery;
        private readonly IMapper _mapper;
        public ReportReadService(IReportQuery reportQuery, IMapper mapper)
        {
            _reportQuery = reportQuery;
            _mapper = mapper;
        }

        public ActionStatus<GetReportDTO> Get(long id)
        {
            ReportDTO entity = _reportQuery.Get(id);
            return new ActionStatus<GetReportDTO>(_mapper.Map<GetReportDTO>(entity));
        }
        public ActionStatus<List<GetReportDTO>> GetPage(RequestReportsPageDTO pageSettings)
        {
            List<ReportDTO> entities = _reportQuery.GetPage(pageSettings);
            List<GetReportDTO> getEntities = new List<GetReportDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetReportDTO>(entity));
            }

            return new ActionStatus<List<GetReportDTO>>(getEntities);
        }
    }
}

