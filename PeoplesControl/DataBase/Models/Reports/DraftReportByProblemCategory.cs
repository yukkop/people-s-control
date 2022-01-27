using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class DraftReportByProblemCategory
    {
        public long Id { get; set; }
        public long DraftReportId { get; set; }
        public DraftReport DraftReport { get; set; }
        public long ProblemCategoryId { get; set; }
        public ProblemCategory ProblemCategory { get; set; }
    }
}
