using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IHCSTypeRepository
    {
        public HCSType Get(long id);
        public List<HCSType> GetAll();
        public HCSType Add(HCSType hcs);
        public Exception SaveChanges();
        public bool Update(HCSType entity); 
        public void Delete(long id);
    }
}
