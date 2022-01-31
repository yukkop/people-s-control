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
    public class MediaDataTypeQuery : IMediaDataTypeQuery
    {
        string _connectionString;
        public MediaDataTypeQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public MediaDataTypeDTO Get(long id)
        {
            string query = $@"SELECT * FROM ""MediaDataTypes""
                            WHERE ""MediaDataTypes"".""Id"" = {id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<MediaDataTypeDTO>(query).FirstOrDefault();
            }
        }

        public List<MediaDataTypeDTO> GetAll()
        {
            string query = $@"SELECT * FROM ""MediaDataTypes""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<MediaDataTypeDTO>(query).ToList();
            }
        }
    }
}
