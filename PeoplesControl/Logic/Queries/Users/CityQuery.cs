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
    public class CityQuery: ICityQuery
    {
        string _connectionString;
        public CityQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public CityDTO Get(long id)
        {
            string query = $@"SELECT * FROM ""Cities""
                            WHERE ""Cities"".""Id"" = {id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<CityDTO>(query).FirstOrDefault();
            }
        }

        public List<CityDTO> GetAll()
        {
            string query = $@"SELECT * FROM ""Cities""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<CityDTO>(query).ToList();
            }
        }
    }
}
