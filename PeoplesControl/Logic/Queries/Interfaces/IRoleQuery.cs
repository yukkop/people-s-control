using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IRoleQuery
    {
        public RoleDTO Get(long id);
        public List<RoleDTO> GetAll();
    }
}
