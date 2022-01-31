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
    public class UserProfileQuery : IUserProfileQuery
    {
        string _connectionString;
        public UserProfileQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public UserProfileDTO Get(long id)
        {
            string query = $@"SELECT ""UsersProfiles"".""Name"", ""Patronymic"", ""Surname"", ""PhoneNumber"", 
                                        ""EmailAddress"", ""RequestAnonymity"", ""NotifyBySMS"", ""NotifyByEmail"", 
                                        ""Avatars"".""Path"" AS ""AvatarPath"",
                    ""Districts"".""Id"" AS ""DistrictId"", ""Districts"".""Name"" AS ""DistrictName"",
					""Cities"".""Id"" AS ""CityId"", ""Cities"".""Name"" AS ""CityName""
                    FROM ""UsersProfiles""
                    LEFT JOIN ""Districts"" ON ""Districts"".""Id"" = ""UsersProfiles"".""DistrictId""
                    LEFT JOIN ""Avatars"" ON ""Avatars"".""Id"" = ""UsersProfiles"".""AvatarId""

                    LEFT JOIN ""Cities"" ON ""Cities"".""Id"" = ""Districts"".""CityId""

                    WHERE ""UsersProfiles"".""Id""={id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<UserProfileDTO>(query).FirstOrDefault();
            }
        }
    }
}
