using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class DraftReportByProblemCategory
    {
        public long Id { get; set; }
        public DraftReport DraftReport { get; set; }
        public CategorieOfProblem CategorieOfProblem { get; set; }
    }
}
