using Dapper;
using Logic.WebEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Logic.Helpers
{
    public class AuthenticationQuery: IAuthenticationQuery
    {
        string _connectionString;
        public AuthenticationQuery(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        
    }
}
