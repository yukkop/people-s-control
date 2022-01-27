using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class HCSTask
    {
        public long Id { get; set; }
        public long HCSId { get; set; }
        public HCS HCS { get; set; }
        public long ReportId { get; set; }
        public Report Report { get; set; }
        public long HCSTaskTypeId { get; set; }
        public HCSTaskType HCSTaskType { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }
    }
}
