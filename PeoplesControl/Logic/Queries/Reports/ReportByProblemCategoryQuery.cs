using Dapper;
using Logic.WebEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Logic.Queries
{
    public class ReportByProblemCategoryQuery : IReportByProblemCategoryQuery
    {
        string _connectionString;
        public ReportByProblemCategoryQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public long? FindInReport(long reportId, long categoryId)
        {
            string query = $@"
SELECT ""ReportsByProblemCategories"".""Id"" 
FROM ""ReportsByProblemCategories""
WHERE ""ReportsByProblemCategories"".""ReportId"" = {reportId} && ""ReportsByProblemCategories"".""ProblemCategoryId"" = {categoryId} ";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<long?>(query).FirstOrDefault();
            }
        } 
    }
}
