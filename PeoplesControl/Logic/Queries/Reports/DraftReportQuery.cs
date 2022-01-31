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
    public class DraftReportQuery : IDraftReportQuery
    {
        string _connectionString;
        public DraftReportQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<DraftReportDTO> GetAllByUserId(long userId)
        {
            string query = $@"SELECT ""DraftReports"".""Id"",""DraftReports"".""Title"",""DraftReports"".""UserId"",""DraftReports"".""Сoordinates"",
""DraftReports"".""ProblemDescription"" FROM ""DraftReports""
WHERE ""DraftReports"".""DateRemoval"" IS NULL AND ""DraftReports"".""UserId""={userId}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<DraftReportDTO>(query).ToList();
            }


        }
        public DraftReportDTO Get(long id)
        {
            string query = $@"SELECT ""DraftReports"".""Id"",""DraftReports"".""Title"",""DraftReports"".""UserId"",""DraftReports"".""Сoordinates"",
""DraftReports"".""ProblemDescription"" FROM ""DraftReports""
WHERE ""DraftReports"".""Id""={id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<DraftReportDTO>(query).FirstOrDefault();
            }


        }
        public List<DraftReportDTO> GetAll()
        {
            string query = $@"SELECT ""DraftReports"".""Id"",""DraftReports"".""Title"",""DraftReports"".""UserId"",""DraftReports"".""Сoordinates"",
""DraftReports"".""ProblemDescription"" FROM ""DraftReports""
WHERE ""DraftReports"".""DateRemoval"" IS NULL";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<DraftReportDTO>(query).ToList();
            }
        }
    }
}
