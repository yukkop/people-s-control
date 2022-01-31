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
    public class HCSQuery : IHCSQuery
    {
        string _connectionString;
        public HCSQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public List<HCSDTO> GetAll()
        {
            string query = $@"SELECT ""HCSs"".""Id"",""HCSs"".""Name"",""HCSs"".""MnemonicName"",""HCSs"".""Description"",
""HCSs"".""ResponsiblePersonId"",""UsersProfiles"".""Name"" AS ""ResponsiblePersonName"",""UsersProfiles"".""Surname"" AS ""ResponsiblePersonSurname"",""UsersProfiles"".""Patronymic"" AS ""ResponsiblePersonPatronymic"",
""HCSs"".""AvatarId"",
""HCSs"".""Hashtag"",""HCSs"".""ContactPhoneNumber"",""HCSs"".""ContactEmail"",""HCSs"".""MinistryEmail"",""HCSs"".""TelegramChannelId"",
""HCSs"".""WebResourseURL"",""HCSs"".""AdditionalInformation"",
""HCSs"".""HCSTypeId"", ""HCSTypes"".""Name"" AS ""HCSTypeName"",
""HCSs"".""IsEmailMailingEnabled"",""HCSs"".""IsDailyReportsGenerating""
FROM ""HCSs""
LEFT JOIN ""HCSTypes"" ON ""HCSTypes"".""Id"" = ""HCSs"".""HCSTypeId""
LEFT JOIN ""Users"" ON ""HCSs"".""ResponsiblePersonId"" = ""Users"".""Id""
LEFT JOIN ""UsersProfiles"" ON ""Users"".""UserProfileId"" = ""UsersProfiles"".""Id""
WHERE ""HCSs"".""IsVisible""=true";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<HCSDTO>(query).ToList();
            }


        }
        public HCSDTO Get(long id)
        {
            string query = $@"SELECT ""HCSs"".""Id"",""HCSs"".""Name"",""HCSs"".""MnemonicName"",""HCSs"".""Description"",
""HCSs"".""ResponsiblePersonId"",""UsersProfiles"".""Name"",""UsersProfiles"".""Surname"",""UsersProfiles"".""Patronymic"",
""HCSs"".""AvatarId"",
""HCSs"".""Hashtag"",""HCSs"".""ContactPhoneNumber"",""HCSs"".""ContactEmail"",""HCSs"".""MinistryEmail"",""HCSs"".""TelegramChannelId"",
""HCSs"".""WebResourseURL"",""HCSs"".""AdditionalInformation"",
""HCSs"".""HCSTypeId"", ""HCSTypes"".""Name"",
""HCSs"".""IsEmailMailingEnabled"",""HCSs"".""IsDailyReportsGenerating""
FROM ""HCSs""
LEFT JOIN ""HCSTypes"" ON ""HCSTypes"".""Id"" = ""HCSs"".""HCSTypeId""
LEFT JOIN ""Users"" ON ""HCSs"".""ResponsiblePersonId"" = ""Users"".""Id""
LEFT JOIN ""UsersProfiles"" ON ""Users"".""UserProfileId"" = ""UsersProfiles"".""Id""
                 WHERE ""HCSs"".""Id""={id}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<HCSDTO>(query).FirstOrDefault();
            }


        }
    }
}
