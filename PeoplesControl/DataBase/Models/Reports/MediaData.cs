using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase.Models
{
    public class MediaData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TypeId { get; set; }
        public MediaDataType Type { get; set; }
        public string Path { get; set; }
        public long DraftReportId { get; set; }
        public DraftReport DraftReport { get; set; }
        public long ReportId { get; set; }
        public Report Report { get; set; }
    }
}
