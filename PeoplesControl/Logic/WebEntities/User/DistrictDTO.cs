using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class DistrictDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CityId { get; set; }
        public string CityName { get; set; }
    }
}
