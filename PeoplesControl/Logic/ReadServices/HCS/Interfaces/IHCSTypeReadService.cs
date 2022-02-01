using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IHCSTypeReadService
    {
        public RequestStatus<List<GetHCSTypeDTO>> GetAll();
        public RequestStatus<GetHCSTypeDTO> Get(long id);
    }
}
