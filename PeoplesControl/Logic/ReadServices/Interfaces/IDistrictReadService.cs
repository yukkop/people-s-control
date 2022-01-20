using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IDistrictReadService
    {
        public ActionStatus<GetDistrictDTO> Get(long id);
        public ActionStatus<List<GetDistrictDTO>> GetAll();
        public ActionStatus<List<GetDistrictDTO>> GetByCityName(string cityName);
    }
}
