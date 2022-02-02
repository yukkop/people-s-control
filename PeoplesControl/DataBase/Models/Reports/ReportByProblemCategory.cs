using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase.Models
{
    public class ReportByProblemCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ReportId { get; set; }
        public Report Report { get; set; }
        public long ProblemCategoryId { get; set; }
        public ProblemCategory ProblemCategory { get; set; }
    }
}
