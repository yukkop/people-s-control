using System;
using System.Security.Cryptography;
using System.Text;


namespace Logic
{
    public class Authorization
    {
        public static byte[] SaltHash(string value, byte[] salt)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] byteValue = Encoding.UTF8.GetBytes(value);
            return sha256Hash.ComputeHash(byteValue.Concat(salt));
        }

        public static string SaltHashToString(string value, byte[] salt)
        {
            return ByteArrToString(SaltHash(value, salt));
        }

        private static string ByteArrToString(byte[] data)
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
