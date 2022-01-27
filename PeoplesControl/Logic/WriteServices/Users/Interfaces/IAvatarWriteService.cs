using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IAvatarWriteService
    {
        public ActionStatus<GetAvatarDTO> Add(CreateAvatarDTO createEntity);
        public bool Update(UpdateAvatarDTO updateEntity);
        public void Delete(long id);
    }
}
