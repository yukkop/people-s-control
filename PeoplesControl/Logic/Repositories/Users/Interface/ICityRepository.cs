using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface ICityRepository
    {
        public City Get(long id);
        public List<City> GetAll();
        public City Add(City entity);
        public bool Update(City entity);
        public void SaveChanges();
        public void Delete(long id);

    }
}
