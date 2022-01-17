using System;
using System.Security.Cryptography;
using System.Text;


namespace Logic
{
    public class Auth
    {
        public static byte[] SaltHash(string value, string salt)
        {
            using SHA256 sha256Hash = SHA256.Create();
            return sha256Hash.ComputeHash(Encoding.UTF8.GetBytes((value + salt)));
        }

        public static string SaltHashToString(string value, string salt)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes((value + salt)));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
