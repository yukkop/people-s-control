using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateMediaDataDTO
    {
        public long TypeId { get; set; }
        public string Path { get; set; }
        public long DraftReportId { get; set; }
        public long ReportId { get; set; }
    }
}
