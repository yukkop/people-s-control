using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IDistrictRepository
    {
        public District Get(long id);
        public List<District> GetAll();
        public District Add(District district);
    }
}
