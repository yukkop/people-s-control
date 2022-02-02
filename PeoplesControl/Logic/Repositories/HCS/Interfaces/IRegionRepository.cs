using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IRegionRepository
    {
        public Region Get(long id);
        public List<Region> GetAll();
        public Region Add(Region Region);
        bool Update(Region entity);
        void SaveChanges();
        void Delete(long id);
    }
}
