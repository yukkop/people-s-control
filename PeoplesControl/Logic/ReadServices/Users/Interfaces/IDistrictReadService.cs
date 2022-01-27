using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IDistrictReadService
    {
        public GetDistrictDTO Get(long id);
        public List<GetDistrictDTO> GetAll();
        public List<GetDistrictDTO> GetByCityName(string cityName);
    }
}
