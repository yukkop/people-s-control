using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Helpers
{
    public interface IAuthenticationService
    {
        public byte[] SaltGen();
        public byte[] SaltHash(string value, byte[] salt);
        public long Authentication(string authorizationBase64String);
        public (string, string) Base64Decode(string authorizationBase64String);
    }
}
