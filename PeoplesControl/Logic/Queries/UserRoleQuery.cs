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
    public class UserRoleQuery: IUserRoleQuery
    {
        string _connectionString;
        public UserRoleQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
        
        public bool CheckUserPermissions(long userId, string[] rolesNames)
        {
            string queryPart = "";

            foreach (string roleName in rolesNames)
            {
                queryPart += $@" ""Roles"".""Name"" = '{roleName}' or";
            }
            queryPart = queryPart.Substring(0, queryPart.Length - 2);

            string query = $@"
SELECT 
""UsersRoles"".""Id"" as ""Id"",
""UsersRoles"".""UserId"" as ""UserId"",
""Roles"".""Id"" as ""RoleId""
FROM ""UsersRoles""
JOIN ""Roles"" on ""Roles"".""Id"" = ""UsersRoles"".""RoleId""
WHERE ""UsersRoles"".""UserId"" = {userId} and {queryPart}";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                if (db.Query<UserRoleDTO>(query).FirstOrDefault() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
