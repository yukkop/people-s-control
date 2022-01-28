using Logic.Queries;
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

        public List<SupportedRegionDTO> GetSupported()
        {
            return _regionQuery.GetSupported();
        }

        public List<UnsupportedRegionDTO> GetUnsupported()
        {
            return _regionQuery.GetUnsupported();
        }
    }
}
