using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.Helpers;

namespace Logic.Repositories
{
    public interface IDistrictRepository
    {
        public District Get(long id);
        public List<District >GetAll();
        public District Add(District district);
        public bool Update(District entity);
        public void Delete(long id);
        public void SaveChanges();
    }
}
