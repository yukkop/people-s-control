using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IHCSTypeWriteService
    {
        public RequestStatus Create(CreateHCSTypeDTO createEntity);
        public bool Update(UpdateHCSTypeDTO updateEntity);
        public void Delete(long id);
    }
}
