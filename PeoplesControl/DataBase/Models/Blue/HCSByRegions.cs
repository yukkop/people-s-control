using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class HCSByRegions
    {
        public long Id { get; set; }
        public HCS HCS { get; set; }
        public SupportedRegion SupportedRegion { get; set; }
    }
}
