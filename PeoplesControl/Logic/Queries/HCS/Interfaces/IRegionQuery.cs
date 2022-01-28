using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IRegionQuery
    {
        public List<SupportedRegionDTO> GetSupported();
        public List<UnsupportedRegionDTO> GetUnsupported();
    }
}
