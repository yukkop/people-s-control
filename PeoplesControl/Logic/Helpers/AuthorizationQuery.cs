using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Logic.Helpers
{
    public class AuthorizationQuery
    {
        string _connectionString;
        public AuthorizationQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

//        public UserPasswordDTO FindUserByLogin(string login)
//        {
//            string query = $@"Select 
//""Users"".""Id"" as ""UserId"",
//""Users"".""UserProfileId"",
//""Users"".""SaltPassword"",
//""Users"".""SaltValue""
//From ""Users""
//Left Join ""UsersProfiles"" on ""Users"".""UserProfileId"" = ""UsersProfiles"".""Id""
//Where ""Users"".""Login"" = 'supper' or ""UsersProfiles"".""EmailAddress"" = 'supper' or ""UsersProfiles"".""PhoneNumber"" = 'supper'";

//            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
//            {
//                return db.Query<UserPasswordDTO>(query).FirstOrDefault();
//            }
//        }
    }
}
