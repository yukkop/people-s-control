using System;
using System.Collections.Generic;
using System.Text;
using NpgsqlTypes;

namespace Logic.WebEntities
{
    public class RequerstNearbyReportsPageDTO
    {
        public long PageSize { get; set; }
        public long PageNum { get; set; }
        public string OrderRule { get; set; }
        public NpgsqlPoint Point { get; set; }
    }
}
