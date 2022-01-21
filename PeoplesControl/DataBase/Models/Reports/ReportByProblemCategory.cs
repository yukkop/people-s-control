using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class ReportByProblemCategory
    {
        public long Id { get; set; }
        public long ReportId { get; set; }
        public Report Report { get; set; }
        public long ProblemCategoryId { get; set; }
        public ProblemCategory ProblemCategory { get; set; }
    }
}
