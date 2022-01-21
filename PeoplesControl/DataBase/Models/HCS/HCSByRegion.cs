using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class HCSByRegion
    {
        public long Id { get; set; }
        public long HCSId { get; set; }
        public HCS HCS { get; set; }
        public long RegionId { get; set; }
        public Region Region { get; set; }
    }
}
