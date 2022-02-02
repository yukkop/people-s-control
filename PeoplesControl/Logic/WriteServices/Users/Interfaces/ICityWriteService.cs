using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface ICityWriteService
    {
        public RequestStatus Add(CreateCityDTO createEntity);
        public bool Update(UpdateCityDTO updateEntity);
        public RequestStatus Delete(long id);
    }
}
