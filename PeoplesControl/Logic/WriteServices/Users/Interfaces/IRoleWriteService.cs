using Logic.Helpers;
using Logic.Repositories;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IRoleWriteService
    {
        public RequestStatus<GetRoleDTO> Add(CreateRoleDTO createEntity);
    }
}
