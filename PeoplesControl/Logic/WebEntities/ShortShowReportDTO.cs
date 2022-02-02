using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class ShortShowReportDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public NpgsqlPoint Coordinates { get; set; }
        public float Rate { get; set; }
        public long ViewsCount { get; set; }
        public long[] ProblemCategoriesIds { get; set; }
        public string[] ProblemCategoriesNames { get; set; }    
        public long[] RelatedReportsIds { get; set; }    
        public long RelatedReportsCount { get; set; }    
    }
}
