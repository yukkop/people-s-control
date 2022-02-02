using Logic.Queries;
using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public class RegionReadService: IRegionReadService
    {
        IRegionQuery _regionQuery;
        public RegionReadService(IRegionQuery regionQuery)
        {
            _regionQuery = regionQuery;
        }

        public RequestStatus< List<SupportedRegionDTO>> GetSupported()
        {
            return new RequestStatus<List<SupportedRegionDTO>>(_regionQuery.GetSupported());
        }

        public RequestStatus<List<UnsupportedRegionDTO>> GetUnsupported()
        {
            return new RequestStatus<List<UnsupportedRegionDTO>>(_regionQuery.GetUnsupported());
        }
    }
}
