using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IDistrictReadService
    {
        public RequestStatus<GetDistrictDTO> Get(long id);
        public RequestStatus< List<GetDistrictDTO>> GetAll();
        public RequestStatus<List<GetDistrictDTO>> GetByCityName(string cityName);
    }
}
