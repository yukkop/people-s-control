using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class UpdateDraftReportDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long UserId { get; set; }
        public NpgsqlPoint Coordinates { get; set; }
        public string ProblemDescription { get; set; }
    }
}
