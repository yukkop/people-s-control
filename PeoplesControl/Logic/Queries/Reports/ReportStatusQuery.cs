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
    public class ReportStatusQuery : IReportStatusQuery
    {
        string _connectionString;
        public ReportStatusQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public ReportStatusDTO Get(long id)
        {
            string query = $@"SELECT * FROM ""ReportStatuses""
                            WHERE ""ReportStatuses"".""Id"" = {id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<ReportStatusDTO>(query).FirstOrDefault();
            }
        }

        public List<ReportStatusDTO> GetAll()
        {
            string query = $@"SELECT * FROM ""ReportStatuses""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<ReportStatusDTO>(query).ToList();
            }
        }
    }
}
