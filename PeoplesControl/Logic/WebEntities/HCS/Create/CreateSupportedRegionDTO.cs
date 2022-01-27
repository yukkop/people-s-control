using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateSupportedRegionDTO
    {
        public long CityId { get; set; }
        public bool IsRegionSupported { get; set; }
        public long QueuePosition { get; set; }
        public long UserId { get; set; }
    }
}
