using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Region
    {
        public long Id { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
        public bool IsRegionSupported { get; set; }
        public long QueuePosition { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }
    }
}
