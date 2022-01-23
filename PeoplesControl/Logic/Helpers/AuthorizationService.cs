using Logic.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Helpers
{
    public class AuthorizationService: IAuthorizationService
    {
        IRoleQuery _roleQuery;
        public AuthorizationService(IRoleQuery roleQuery)
        {
            _roleQuery = roleQuery;
        }
        public void Authorization(long userId, string role)
        {

        }
    }
}
