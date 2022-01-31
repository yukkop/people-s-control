using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IHCSTypeQuery
    {
        public HCSTypeDTO Get(long id);
        public List<HCSTypeDTO> GetAll();
    }
}
