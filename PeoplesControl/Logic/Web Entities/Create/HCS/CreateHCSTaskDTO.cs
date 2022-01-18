using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Web_Entities
{
    public class CreateHCSTaskDTO
    {
        public long HCSId { get; set; }
        public long ReportId { get; set; }
        public long TaskTypeId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public long UserId { get; set; }
    }
}
