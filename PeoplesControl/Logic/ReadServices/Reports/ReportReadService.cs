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

        public RequestStatus<GetReportDTO> Get(long id)
        {
            ReportDTO entity = _reportQuery.Get(id);
            return new RequestStatus<GetReportDTO>(_mapper.Map<GetReportDTO>(entity));
        }

        public RequestStatus<List<ShortShowReportDTO>> GetPage(RequestReportsPageDTO pageSettings)
        {
            List<ShortShowReportDTO> entities;
            try
            {
                entities = _reportQuery.GetPage(pageSettings);
            }
            catch (Exception e)
            {
                return RequestStatus<List<ShortShowReportDTO>>.Exception(e);
            }

            return new RequestStatus<List<ShortShowReportDTO>>(entities);
        }
        public RequestStatus<List<ShortShowReportDTO>> GetPageNearbyReports(RequerstNearbyReportsPageDTO pageSettings)
        {
            List<ShortShowReportDTO> entities;
            try
            {
                entities = _reportQuery.GetPageNearbyReports(pageSettings);
            }
            catch (Exception e)
            {
                return RequestStatus<List<ShortShowReportDTO>>.Exception(e);
            }

            return new RequestStatus<List<ShortShowReportDTO>>(entities);
        }
        public RequestStatus<GetReportDTO> GetByCategory(long categotyId)
        {
            ReportDTO entities;
            try
            {
                entities = _reportQuery.GetByCategoty(categotyId);
            }
            catch (Exception e)
            {
                return RequestStatus<GetReportDTO>.Exception(e);
            }

            return new RequestStatus<GetReportDTO>(_mapper.Map<GetReportDTO>(entities));
        }
    }
}

