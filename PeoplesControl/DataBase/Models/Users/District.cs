using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class District
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
    }
}
