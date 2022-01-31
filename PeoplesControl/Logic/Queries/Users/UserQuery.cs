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
    public class UserQuery: IUserQuery
    {
        string _connectionString;
        public UserQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public UserDTO Get(long id)
        {
            string query = $@"
Select
""Users"".""Id"",
""Users"".""UserProfileId"",
""Users"".""Login"",
""Users"".""SMSConfirmationCode"",
""Users"".""EmailConfirmationCode""
From ""Users""
Where ""Users"".""Id"" = 1";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<UserDTO>(query).FirstOrDefault();
            }
        }

        public UserPasswordDTO FindUserByLogin(string login)
        {
            string query = $@"Select 
""Users"".""Id"" as ""UserId"",
""Users"".""UserProfileId"",
""Users"".""SaltPassword"",
""Users"".""SaltValue""
From ""Users""
Left Join ""UsersProfiles"" on ""Users"".""UserProfileId"" = ""UsersProfiles"".""Id""
Where ""Users"".""Login"" = '{login}' or ""UsersProfiles"".""EmailAddress"" = '{login}' or ""UsersProfiles"".""PhoneNumber"" = '{login}'";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<UserPasswordDTO>(query).FirstOrDefault();
            }
        }
    }
}
