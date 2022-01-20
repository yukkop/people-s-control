using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class UpdateDistrictDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long CityId { get; set; }
    }
}
