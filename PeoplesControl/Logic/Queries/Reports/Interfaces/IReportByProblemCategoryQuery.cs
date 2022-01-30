using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IReportByProblemCategoryQuery
    {
        public long? FindInReport(long reportId, long categoryId);
    }
}
