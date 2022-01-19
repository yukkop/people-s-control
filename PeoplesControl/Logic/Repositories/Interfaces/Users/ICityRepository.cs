using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface ICityRepository
    {
        public City Get(int id);
        public List<City> GetAll();
        public City Add(City city);
        
    }
}
