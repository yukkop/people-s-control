using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class SupportedRegion
    {
        public long Id { get; set; }
        public City City { get; set; }
        public bool IsRegionSupported { get; set; }
        public long QueuePosition { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }


    }
}
