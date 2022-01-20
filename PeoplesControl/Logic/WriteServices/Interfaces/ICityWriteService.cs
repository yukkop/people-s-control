using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface ICityWriteService
    {
        public ActionStatus<GetCityDTO> Add(CreateCityDTO createEntity);
        public bool Update(UpdateCityDTO updateEntity);
        public void Delete(long id);
    }
}
