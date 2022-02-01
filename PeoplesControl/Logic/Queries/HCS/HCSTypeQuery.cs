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
    public class HCSTypeQuery : IHCSTypeQuery
    {
        string _connectionString;
        public HCSTypeQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<HCSTypeDTO> GetAll()
        {
            string query = $@"SELECT ""HCSTypes"".""Id"", ""HCSTypes"".""Name"" FROM ""HCSTypes""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<HCSTypeDTO>(query).ToList();
            }


        }
        public HCSTypeDTO Get(long id)
        {
            string query = $@"SELECT ""HCSTypes"".""Id"", ""HCSTypes"".""Name"" FROM ""HCSTypes""
                 WHERE ""HCSTypes"".""Id""={id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<HCSTypeDTO>(query).FirstOrDefault();
            }


        }
    }
}
