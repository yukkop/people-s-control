﻿using Dapper;
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
            string query = $@"SELECT """"Reports"".""Id"", ""Reports"".""UserId"", ""Reports"".""Title"", 
        ""Reports"".""RelationReportId"", ""Reports"".""Address"", ""Reports"".""StatusId"",
		""ReportStatuses"".""Name"" AS ""StatusName"", ""Reports"".""Coordinates"", 
		""Reports"".""DateConsideration"", ""Reports"".""DateStartExecution"", 
		""Reports"".""DateFinishExecution"", ""Reports"".""DateFinalControl"",
		""Reports"".""IsRequestModeration"", ""Reports"".""ModeratorId"",
		""Reports"".""ProblemDescription"", ""Reports"".""BaseRate"",
		""Reports"".""IsAnonymously"",
        count(""ReportsViews"".""UserId"") AS ""ViewsCount"",
		array_agg(DISTINCT ""ProblemCategories"".""Id"") AS ""ProblemCategoriesIds"",
		array_agg(DISTINCT ""ProblemCategories"".""Name"") AS ""ProblemCategoriesNames"",
		
		CASE WHEN ""UsersProfiles"".""Name"" != 'Guest' THEN 10 ELSE 0

             END + CASE WHEN ""UsersProfiles"".""PhoneNumber"" IS NOT NULL THEN 20 ELSE 0

             END + CASE WHEN ""Users"".""DateSMSConfirmation"" IS NOT NULL THEN 50 ELSE 0

             END + CASE WHEN ""Reports"".""Coordinates"" IS NOT NULL THEN 20 ELSE 0

             END + CASE WHEN ""Reports"".""ProblemDescription"" IS NOT NULL THEN 10 ELSE 0


             END + CASE WHEN ""ProblemCategories"".""Id"" IS NOT NULL THEN 5 ELSE 0

            END as ""Rate""

                    FROM ""Reports""
                    LEFT JOIN ""ReportStatuses"" ON ""ReportStatuses"".""Id"" = ""Reports"".""StatusId""
                    LEFT JOIN ""ReportsViews"" ON ""ReportsViews"".""ReportId"" = ""Reports"".""Id""
                    LEFT JOIN ""ReportsByProblemCategories"" ON ""ReportsByProblemCategories"".""ReportId"" = ""Reports"".""Id""
                    LEFT JOIN ""ProblemCategories"" ON  ""ProblemCategories"".""Id"" = ""ReportsByProblemCategories"".""ProblemCategoryId""

                    LEFT JOIN ""Users"" ON ""Users"".""Id"" = ""Reports"".""UserId""

                    LEFT JOIN ""UsersProfiles"" ON ""Users"".""UserProfileId"" = ""UsersProfiles"".""Id""
                    WHERE ""Reports"".""IsDeleted"" = false                    
WHERE ""Reports"".""IsDeleted"" = false AND ""Reports"".""Id"" = {id}

GROUP BY ""Reports"".""Id"", ""Reports"".""UserId"", ""Reports"".""Title"", 

        ""Reports"".""RelationReportId"", ""Reports"".""Address"", ""Reports"".""StatusId"",
		""StatusName"",
		""Reports"".""DateConsideration"", ""Reports"".""DateStartExecution"", 
		""Reports"".""DateFinishExecution"", ""Reports"".""DateFinalControl"",
		""Reports"".""IsRequestModeration"", ""Reports"".""ModeratorId"",
		""Reports"".""ProblemDescription"", ""Reports"".""BaseRate"",
		""Reports"".""IsAnonymously"",
		""UsersProfiles"".""Name"",""UsersProfiles"".""PhoneNumber"",""Users"".""DateSMSConfirmation"",""ProblemCategories"".""Id""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<ReportDTO>(query).FirstOrDefault();
            }
        
        
        }

        public List<ReportDTO> GetPage(RequestReportsPageDTO pageSettings)
        {
            string query = $@"SELECT """"Reports"".""Id"", ""Reports"".""UserId"", ""Reports"".""Title"", 
        ""Reports"".""RelationReportId"", ""Reports"".""Address"", ""Reports"".""StatusId"",
		""ReportStatuses"".""Name"" AS ""StatusName"", ""Reports"".""Coordinates"", 
		""Reports"".""DateConsideration"", ""Reports"".""DateStartExecution"", 
		""Reports"".""DateFinishExecution"", ""Reports"".""DateFinalControl"",
		""Reports"".""IsRequestModeration"", ""Reports"".""ModeratorId"",
		""Reports"".""ProblemDescription"", ""Reports"".""BaseRate"",
		""Reports"".""IsAnonymously"",
        count(""ReportsViews"".""UserId"") AS ""ViewsCount"",
		array_agg(DISTINCT ""ProblemCategories"".""Id"") AS ""ProblemCategoriesIds"",
		array_agg(DISTINCT ""ProblemCategories"".""Name"") AS ""ProblemCategoriesNames"",
		
		CASE WHEN ""UsersProfiles"".""Name"" != 'Guest' THEN 10 ELSE 0

             END + CASE WHEN ""UsersProfiles"".""PhoneNumber"" IS NOT NULL THEN 20 ELSE 0

             END + CASE WHEN ""Users"".""DateSMSConfirmation"" IS NOT NULL THEN 50 ELSE 0

             END + CASE WHEN ""Reports"".""Coordinates"" IS NOT NULL THEN 20 ELSE 0

             END + CASE WHEN ""Reports"".""ProblemDescription"" IS NOT NULL THEN 10 ELSE 0


             END + CASE WHEN ""ProblemCategories"".""Id"" IS NOT NULL THEN 5 ELSE 0

            END as ""Rate""

                    FROM ""Reports""
                    LEFT JOIN ""ReportStatuses"" ON ""ReportStatuses"".""Id"" = ""Reports"".""StatusId""
                    LEFT JOIN ""ReportsViews"" ON ""ReportsViews"".""ReportId"" = ""Reports"".""Id""
                    LEFT JOIN ""ReportsByProblemCategories"" ON ""ReportsByProblemCategories"".""ReportId"" = ""Reports"".""Id""
                    LEFT JOIN ""ProblemCategories"" ON  ""ProblemCategories"".""Id"" = ""ReportsByProblemCategories"".""ProblemCategoryId""

                    LEFT JOIN ""Users"" ON ""Users"".""Id"" = ""Reports"".""UserId""

                    LEFT JOIN ""UsersProfiles"" ON ""Users"".""UserProfileId"" = ""UsersProfiles"".""Id""
                    WHERE ""Reports"".""IsDeleted"" = false

GROUP BY ""Reports"".""Id"", ""Reports"".""UserId"", ""Reports"".""Title"", 

        ""Reports"".""RelationReportId"", ""Reports"".""Address"", ""Reports"".""StatusId"",
		""StatusName"",
		""Reports"".""DateConsideration"", ""Reports"".""DateStartExecution"", 
		""Reports"".""DateFinishExecution"", ""Reports"".""DateFinalControl"",
		""Reports"".""IsRequestModeration"", ""Reports"".""ModeratorId"",
		""Reports"".""ProblemDescription"", ""Reports"".""BaseRate"",
		""Reports"".""IsAnonymously"",
		""UsersProfiles"".""Name"",""UsersProfiles"".""PhoneNumber"",""Users"".""DateSMSConfirmation"",""ProblemCategories"".""Id""
                    ORDER BY ""{pageSettings.OrderRule}""
                    LIMIT {pageSettings.PageSize} OFFSET {pageSettings.PageSize * (pageSettings.PageNum - 1)}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<ReportDTO>(query).ToList();
            }
        }
    }
}
