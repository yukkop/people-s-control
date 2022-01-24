using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IRoleReadService
    {
        public ActionStatus<GetRoleDTO> Get(long id);

        public ActionStatus<List<GetRoleDTO>> GetAll();
    }
}
