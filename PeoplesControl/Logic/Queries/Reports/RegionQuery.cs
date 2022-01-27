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
    public class RegionQuery
    {

        string _connectionString;
        public RegionQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<SupportedRegionDTO> GetSupported()
        {
            string query = $@"
SELECT 
""Regions"".""Id"", 
""Cities"".""Name""
FROM ""Regions""
JOIN ""Cities"" on ""Cities"".""Id"" = ""Regions"".""CityId""
WHERE ""IsRegionSupported"" = true
";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<SupportedRegionDTO>(query).ToList();
            }


        }
        public List<UnsupportedRegionDTO> GetUnsupported()
        {
            string query = $@"
SELECT 
""Regions"".""Id"", 
""Cities"".""Name""
FROM ""Regions""
JOIN ""Cities"" on ""Cities"".""Id"" = ""Regions"".""CityId""
WHERE ""IsRegionSupported"" = false
";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<UnsupportedRegionDTO>(query).ToList();
            }


        }
    }
}
