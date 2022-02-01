using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IHCSQuery
    {
        public HCSDTO Get(long id);
        public List<HCSDTO> GetAll();
    }
}
