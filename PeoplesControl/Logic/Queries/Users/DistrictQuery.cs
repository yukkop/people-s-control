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
    public class DistrictQuery : IDistrictQuery
    {
        string _connectionString;
        public DistrictQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public DistrictDTO Get(long id)
        {
            string query = $@"
                            SELECT 
                            ""Districts"".""Id"", 
                            ""Districts"".""Name"", 
                            ""Cities"".""Id"" as CityId, 
                            ""Cities"".""Name"" as CityName
                            FROM ""Districts""
                            JOIN ""Cities"" on ""Cities"".""Id"" = ""Districts"".""CityId""
                            WHERE ""Districts"".""Id"" = {id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<DistrictDTO>(query).FirstOrDefault();
            }
        }

        public List<DistrictDTO> GetAll()
        {
            string query = $@"SELECT 
                                    ""Districts"".""Id"", 
                                    ""Districts"".""Name"", 
                                    ""Cities"".""Id"" as CityId, 
                                    ""Cities"".""Name"" as CityName
                            FROM ""Districts""
                            JOIN ""Cities"" on ""Cities"".""Id"" = ""Districts"".""CityId""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<DistrictDTO>(query).ToList();
            }
        }

        public List<DistrictDTO> GetByCityName(string cityName)
        {
            string query = $@"
            SELECT 
            ""Districts"".""Id"", 
            ""Districts"".""Name"",
            ""Cities"".""Id"" as ""CityId"",
            ""Cities"".""Name"" as ""CityName""
            FROM ""Districts""
            INNER JOIN ""Cities"" ON ""Cities"".""Id""=""Districts"".""CityId""
            WHERE ""Cities"".""Name"" = '{cityName}'";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<DistrictDTO>(query).ToList();
            }
        }
    }
}
