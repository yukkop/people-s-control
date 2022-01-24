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
    public class AvatarQuery : IAvatarQuery
    {
        string _connectionString;
        public AvatarQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public AvatarDTO Get(long id)
        {
            string query = $@"SELECT * FROM ""Avatars""
                            WHERE ""Avatars"".""Id"" = {id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<AvatarDTO>(query).FirstOrDefault();
            }
        }

        public List<AvatarDTO> GetAll()
        {
            string query = $@"SELECT * FROM ""Avatars""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<AvatarDTO>(query).ToList();
            }
        }
    }
}
