using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    class CreateScheduleDTO
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public long HCSId { get; set; }
    }
}
