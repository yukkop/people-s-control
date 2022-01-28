using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IAvatarReadService
    {
        public RequestStatus<GetAvatarDTO> Get(long id);
        public RequestStatus<List<GetAvatarDTO>> GetAll();
    }
}
