using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IDistrictQuery
    {
        public DistrictDTO Get(long id);
        public List<DistrictDTO> GetAll();
        public List<DistrictDTO> GetByCityName(string cityName);
    }
}
