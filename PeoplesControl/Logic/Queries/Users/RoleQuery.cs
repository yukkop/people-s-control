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
    public class RoleQuery: IRoleQuery
    {
        string _connectionString;
        public RoleQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public long FindIdByName(string name)
        {
            string query = $@"SELECT 
""Roles"".""Id""
FROM ""Roles""
WHERE ""Roles"".""Name"" = '{name}'";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<long>(query).FirstOrDefault();
            }
        }

        public RoleDTO Get(long id)
        {
            string query = $@"SELECT 
""Roles"".""Id"",
""Roles"".""Name"",
""Roles"".""MnemonicName"",
""Removal"".""Id"" as ""RemovalActionId"",
""UserMadeRemoval"".""Id"" as ""UserMadeRemovalId"",
""Removal"".""Date"" as ""DateRemoval"",
""LastEditing"".""Id"" as ""LastEditingActionId"",
""UserMadeLastEditing"".""Id"" as ""UserMadeLastEditingId"",
""LastEditing"".""Date"" as ""DateLastEditing"",
""Creation"".""Id"" as ""CreationActionId"",
""UserMadeCreation"".""Id"" as ""UserMadeCreationId"",
""Creation"".""Date"" as ""DateCreation""
FROM ""Roles""
LEFT JOIN ""ActionMeta"" as ""Removal"" on ""Roles"".""RemovalId"" = ""Removal"".""Id""
LEFT JOIN ""ActionMeta"" as ""LastEditing"" on ""Roles"".""LastEditingId"" = ""LastEditing"".""Id""
LEFT JOIN ""ActionMeta"" as ""Creation"" on ""Roles"".""CreationId"" = ""Creation"".""Id""
LEFT JOIN ""Users"" as ""UserMadeRemoval"" on ""Removal"".""UserId"" = ""UserMadeRemoval"".""Id""
LEFT JOIN ""Users"" as ""UserMadeLastEditing"" on ""LastEditing"".""UserId"" = ""UserMadeLastEditing"".""Id""
LEFT JOIN ""Users"" as ""UserMadeCreation"" on ""Creation"".""UserId"" = ""UserMadeCreation"".""Id""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<RoleDTO>(query).FirstOrDefault();
            }
        }

        public List<RoleDTO> GetAll()
        {
            string query = $@"SELECT 
""Roles"".""Id"",
""Roles"".""Name"",
""Roles"".""MnemonicName"",
""Removal"".""Id"" as ""RemovalActionId"",
""UserMadeRemoval"".""Id"" as ""UserMadeRemovalId"",
""Removal"".""Date"" as ""DateRemoval"",
""LastEditing"".""Id"" as ""LastEditingActionId"",
""UserMadeLastEditing"".""Id"" as ""UserMadeLastEditingId"",
""LastEditing"".""Date"" as ""DateLastEditing"",
""Creation"".""Id"" as ""CreationActionId"",
""UserMadeCreation"".""Id"" as ""UserMadeCreationId"",
""Creation"".""Date"" as ""DateCreation""
FROM ""Roles""
LEFT JOIN ""ActionMeta"" as ""Removal"" on ""Roles"".""RemovalId"" = ""Removal"".""Id""
LEFT JOIN ""ActionMeta"" as ""LastEditing"" on ""Roles"".""LastEditingId"" = ""LastEditing"".""Id""
LEFT JOIN ""ActionMeta"" as ""Creation"" on ""Roles"".""CreationId"" = ""Creation"".""Id""
LEFT JOIN ""Users"" as ""UserMadeRemoval"" on ""Removal"".""UserId"" = ""UserMadeRemoval"".""Id""
LEFT JOIN ""Users"" as ""UserMadeLastEditing"" on ""LastEditing"".""UserId"" = ""UserMadeLastEditing"".""Id""
LEFT JOIN ""Users"" as ""UserMadeCreation"" on ""Creation"".""UserId"" = ""UserMadeCreation"".""Id""";

            using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
            {
                return db.Query<RoleDTO>(query).ToList();
            }
        }
    }
}
