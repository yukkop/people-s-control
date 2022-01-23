using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public class UserRoleQuery: IUserRoleQuery
    {
        string _connectionString;
        //public CityQuery(IConfiguration configuration)
        //{
        //    _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        //}

        //public CityDTO FindByUserId(long id)
        //{
        //    string query = $@"SELECT * FROM ""Cities""
        //                    WHERE ""Cities"".""Id"" = {id}";

        //    using (IDbConnection db = new Npgsql.NpgsqlConnection(_connectionString))
        //    {
        //        return db.Query<CityDTO>(query).FirstOrDefault();
        //    }
        //}
    }
}
