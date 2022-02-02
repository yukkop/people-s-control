using Logic.Queries;
using Logic.WebEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Helpers
{
    public class AuthorizationService: IAuthorizationService
    {
        IUserRoleQuery _roleUserQuery;
        IAuthenticationService _authenticationService;
        IConfiguration _configuration;
        public AuthorizationService(IUserRoleQuery roleUserQuery, IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _roleUserQuery = roleUserQuery;
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        public (bool, long) Authorization(string token, string rolesString)
        {
            long userId = _authenticationService.Authentication(token);


            if (rolesString == _configuration["Roles"].Split(",")[1] && userId != 0)
            {
                    return (true, userId);
            }

            string[] roles = rolesString.Split(",");
            return (_roleUserQuery.CheckUserPermissions(userId, roles), userId);
        }
    }
}
