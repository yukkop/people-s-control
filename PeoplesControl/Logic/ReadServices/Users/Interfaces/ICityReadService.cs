using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface ICityReadService
    {
        public GetCityDTO Get(long id);
        public List<GetCityDTO> GetAll();
    }
}
