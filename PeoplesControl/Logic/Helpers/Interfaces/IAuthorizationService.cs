using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Helpers
{
    public interface IAuthorizationService
    {
        public (bool, long) Authorization(string token, string rolesString);
    }
}
