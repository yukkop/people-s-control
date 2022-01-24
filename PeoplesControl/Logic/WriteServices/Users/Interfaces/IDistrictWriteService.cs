using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IDistrictWriteService
    {
        public ActionStatus<GetDistrictDTO> Add(CreateDistrictDTO createEntity);
        public bool Update(UpdateDistrictDTO updateEntity);
        public void Delete(long id);
    }
}
