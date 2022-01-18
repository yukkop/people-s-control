using System;
using System.Security.Cryptography;
using System.Text;


namespace Logic
{
    public class Auth
    {
        public static byte[] SaltHash(string value, byte[] salt)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] byteValue = Encoding.UTF8.GetBytes(value);
            byte[] byteConcat = new byte[byteValue.Length + salt.Length];
            for (int i = 0; i < byteValue.Length + salt.Length; i++)
            {
                if (i < byteValue.Length)
                {
                    byteConcat[i] = byteValue[i];

                }
                else
                {
                    byteConcat[i] = salt[i-byteValue.Length];

                }
            }
            return sha256Hash.ComputeHash(byteConcat);
        }

        public static string SaltHashToString(string value, byte[] salt)
        {
            return ByteArrToString(SaltHash(value, salt));
        }

        public static string ByteArrToString(byte[] data)
        {
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static byte[] SaltGen()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            rng.GetBytes(salt);
            return salt;
        }
    }
}
