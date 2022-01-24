using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IAvatarReadService
    {
        public ActionStatus<GetAvatarDTO> Get(long id);
        public ActionStatus<List<GetAvatarDTO>> GetAll();
    }
}
