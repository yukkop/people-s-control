using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface ICityQuery
    {
        public CityDTO Get(long id);
        public List<CityDTO> GetAll();
    }
}
