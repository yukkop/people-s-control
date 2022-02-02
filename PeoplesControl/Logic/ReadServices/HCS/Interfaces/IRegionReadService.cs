using Logic.WebEntities;
using Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IRegionReadService
    {
        public RequestStatus< List<SupportedRegionDTO>> GetSupported();
        public RequestStatus<List<UnsupportedRegionDTO>> GetUnsupported();
    }
}
