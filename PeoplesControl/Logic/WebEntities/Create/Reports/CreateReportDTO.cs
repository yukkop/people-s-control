using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateReportDTO
    {
        public string Title { get; set; }
        public long UserId { get; set; }
        public long RelationReportId { get; set; }
        public string Adress { get; set; }
        public long StatusId { get; set; }
        public NpgsqlPoint Coordinates { get; set; }
        public DateTime DateConsideration { get; set; }
        public DateTime DateStartExecution { get; set; }
        public DateTime DateFinishExecution { get; set; }
        public DateTime DateFinalControl { get; set; }
        public bool IsRequestModeration { get; set; }
        public long ModeratorId { get; set; }
        public string ProblemDescription { get; set; }
        public float BaseRate { get; set; }

    }
}
