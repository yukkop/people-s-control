using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IHCSRepository
    {
        public HCS Get(long id);
        public List<HCS> GetAll();
        public HCS Add(HCS hcs);
        public Exception SaveChanges();
        public bool Update(HCS entity);
    }
}
