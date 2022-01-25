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
    public class ReportQuery : IReportQuery
    {
        string _connectionString;
        public ReportQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public ReportDTO Get(long id)
        {
            string query = $@"SELECT ""Reports"".""Id"", ""Reports"".""UserId"", ""Reports"".""Title"", 

        ""Reports"".""RelationReportId"", ""Reports"".""Address"", ""Reports"".""StatusId"",
		""ReportStatuses"".""Name"" AS ""StatusName"", ""Reports"".""Coordinates"", 
		""Reports"".""DateConsideration"", ""Reports"".""DateStartExecution"", 
		""Reports"".""DateFinishExecution"", ""Reports"".""DateFinalControl"",
		""Reports"".""IsRequestModeration"", ""Reports"".""ModeratorId"",
		""Reports"".""ProblemDescription"", ""Reports"".""BaseRate"",
		""Reports"".""IsAnonymously"",
        count(""ReportsViews"".""UserId"") AS ""ViewsCount""
                            FROM ""Reports""
                            LEFT JOIN ""ReportStatuses"" ON ""ReportStatuses"".""Id"" = ""Reports"".""StatusId""
                            LEFT JOIN ""ReportsViews"" ON ""ReportsViews"".""ReportId"" = ""Reports"".""Id""

                            WHERE ""Reports"".""IsDeleted"" = false AND ""Reports"".""Id"" = {id}


                            GROUP BY ""Reports"".""Id"", ""Reports"".""UserId"", ""Reports"".""Title"", 

        ""Reports"".""RelationReportId"", ""Reports"".""Address"", ""Reports"".""StatusId"",
		""StatusName"",
		""Reports"".""DateConsideration"", ""Reports"".""DateStartExecution"", 
		""Reports"".""DateFinishExecution"", ""Reports"".""DateFinalControl"",
		""Reports"".""IsRequestModeration"", ""Reports"".""ModeratorId"",
		""Reports"".""ProblemDescription"", ""Reports"".""BaseRate"",
		""Reports"".""IsAnonymously""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<ReportDTO>(query).FirstOrDefault();
            }
        }

        public List<ReportDTO> GetPage(RequestReportsPageDTO pageSettings)
        {
            string query = $@"SELECT ""Reports"".""Id"", ""Reports"".""UserId"", ""Reports"".""Title"", 
        ""Reports"".""RelationReportId"", ""Reports"".""Address"", ""Reports"".""StatusId"",
		""ReportStatuses"".""Name"" AS ""StatusName"", ""Reports"".""Coordinates"", 
		""Reports"".""DateConsideration"", ""Reports"".""DateStartExecution"", 
		""Reports"".""DateFinishExecution"", ""Reports"".""DateFinalControl"",
		""Reports"".""IsRequestModeration"", ""Reports"".""ModeratorId"",
		""Reports"".""ProblemDescription"", ""Reports"".""BaseRate"",
		""Reports"".""IsAnonymously"",
        count(""ReportsViews"".""UserId"") AS ""ViewsCount""
                    FROM ""Reports""
                    LEFT JOIN ""ReportStatuses"" ON ""ReportStatuses"".""Id"" = ""Reports"".""StatusId""
                    LEFT JOIN ""ReportsViews"" ON ""ReportsViews"".""ReportId"" = ""Reports"".""Id""
                    WHERE ""Reports"".""IsDeleted"" = false
GROUP BY ""Reports"".""Id"", ""Reports"".""UserId"", ""Reports"".""Title"", 

        ""Reports"".""RelationReportId"", ""Reports"".""Address"", ""Reports"".""StatusId"",
		""StatusName"",
		""Reports"".""DateConsideration"", ""Reports"".""DateStartExecution"", 
		""Reports"".""DateFinishExecution"", ""Reports"".""DateFinalControl"",
		""Reports"".""IsRequestModeration"", ""Reports"".""ModeratorId"",
		""Reports"".""ProblemDescription"", ""Reports"".""BaseRate"",
		""Reports"".""IsAnonymously""
                    ORDER BY ""{pageSettings.OrderRule}""
                    LIMIT {pageSettings.PageSize} OFFSET {pageSettings.PageSize*(pageSettings.PageNum-1)}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<ReportDTO>(query).ToList();
            }
        }
    }
}
