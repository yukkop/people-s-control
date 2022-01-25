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
    public class ProblemCategoryQuery : IProblemCategoryQuery
    {
        string _connectionString;
        public ProblemCategoryQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public ProblemCategoryDTO Get(long id)
        {
            string query = $@"SELECT ""ProblemCategories"".""Id"",""ProblemCategories"".""Name"", ""ProblemCategories"".""MnemonicName"",
                                ""ProblemCategories"".""HashTag"",""ProblemCategories"".""AvatarId"",
                ""ProblemCategories"".""IsActive"",""ProblemCategories"".""IsVisible""
                FROM ""ProblemCategories""
                WHERE ""ProblemCategories"".""IsVisible""=true AND ""ProblemCategories"".""IsActive""=true
AND""ProblemCategories"".""Id""={id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<ProblemCategoryDTO>(query).FirstOrDefault();
            }
        }

        public List<ProblemCategoryDTO> GetAll()
        {
            string query = $@"SELECT ""ProblemCategories"".""Id"",""ProblemCategories"".""Name"", ""ProblemCategories"".""MnemonicName"",
                                ""ProblemCategories"".""HashTag"",""ProblemCategories"".""AvatarId"",
                ""ProblemCategories"".""IsActive"",""ProblemCategories"".""IsVisible""
                FROM ""ProblemCategories""
                WHERE ""ProblemCategories"".""IsVisible""=true AND ""ProblemCategories"".""IsActive""=true";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<ProblemCategoryDTO>(query).ToList();
            }
        }
    }
}
