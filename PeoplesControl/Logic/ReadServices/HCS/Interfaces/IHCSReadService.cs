using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IHCSReadService
    {
        public RequestStatus<List<GetHCSDTO>> GetAll();
        public RequestStatus<GetHCSDTO> Get(long id);
    }
}
