using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IRoleReadService
    {
        public RequestStatus<GetRoleDTO> Get(long id);

        public RequestStatus<List<GetRoleDTO>> GetAll();
    }
}
