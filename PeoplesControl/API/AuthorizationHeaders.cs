using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class AuthorizationHeaders
    {
        [FromHeader]
        public string Username { get; set; }

        [FromHeader]
        public string Password { get; set; }
    }
}
