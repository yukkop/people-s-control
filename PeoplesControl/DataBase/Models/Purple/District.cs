using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    class District
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
    }
}
