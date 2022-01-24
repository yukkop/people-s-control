using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Helpers
{
    public interface IAuthorizationService
    {
        public bool Authorization(string token, string roles);
    }
}
