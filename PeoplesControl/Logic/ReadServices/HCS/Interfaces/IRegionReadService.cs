using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IRegionReadService
    {
        public List<SupportedRegionDTO> GetSupported();
        public List<UnsupportedRegionDTO> GetUnsupported();
    }
}
