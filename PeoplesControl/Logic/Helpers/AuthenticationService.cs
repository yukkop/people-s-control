using System;
using System.Security.Cryptography;
using System.Text;
using Logic.WebEntities;
using System.Linq;
using Logic.Queries;

namespace Logic.Helpers
{
    public class AuthenticationService: IAuthenticationService
    {
        IUserQuery _userQuery;
        public AuthenticationService(IUserQuery userQuery)
        {
            _userQuery = userQuery;
        }

        /// <summary>
        /// If authentication failed returns 0
        /// </summary>
        /// <param name="authorizationBase64String"></param>
        /// <returns></returns>
        public long Authentication(string authorizationBase64String)
        {
            if (authorizationBase64String == null)
                return 0;
            var (login, password) = Base64Decode(authorizationBase64String);
            UserPasswordDTO user = _userQuery.FindUserByLogin(login);
            if (user == null)
            {
                return 0;
            }
            byte[] saltPasword = SaltHash(password, user.SaltValue);

            if (user.SaltPassword.SequenceEqual(saltPasword))
                return user.UserId;
            return 0;
        }

        public (string, string) Base64Decode(string authorizationBase64String)
        {
            authorizationBase64String = authorizationBase64String.Split(" ")[1];
            authorizationBase64String = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authorizationBase64String));
            string login = authorizationBase64String.Split(":")[0];
            string password = authorizationBase64String.Split(":")[1];
            return (login, password);
        }
        public byte[] SaltGen()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            rng.GetBytes(salt);
            return salt;
        }

        public byte[] SaltHash(string value, byte[] salt)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] byteValue = Encoding.UTF8.GetBytes(value);
            return sha256Hash.ComputeHash(byteValue.Concat(salt));
        }

        //public string SaltHashToString(string value, byte[] salt)
        //{
        //    return ByteArrToString(SaltHash(value, salt));
        //}

        //private string ByteArrToString(byte[] data)
        //{
        //    var sBuilder = new StringBuilder();
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }
        //    return sBuilder.ToString();
        //}
    }

    public static class ByteExtansion
    {
        public static byte[] Concat(this byte[] a, byte[] b)
        {
            byte[] byteConcat = new byte[a.Length + b.Length];
            for (int i = 0; i < a.Length + b.Length; i++)
            {
                if (i < a.Length)
                {
                    byteConcat[i] = a[i];

                }
                else
                {
                    byteConcat[i] = b[i - a.Length];

                }
            }
            return byteConcat;
        }
    }
}
