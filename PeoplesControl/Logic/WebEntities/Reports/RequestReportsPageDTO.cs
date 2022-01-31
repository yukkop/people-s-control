using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class RequestReportsPageDTO
    {
        public long PageSize { get; set; }
        public long PageNum { get; set; }
        public string OrderRule { get; set; }
    }
}
