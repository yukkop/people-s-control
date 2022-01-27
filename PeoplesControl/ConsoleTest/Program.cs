using Logic.Helpers;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        public static byte[] SaltGen()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            rng.GetBytes(salt);
            return salt;
        }

        public static byte[] SaltHash(string value, byte[] salt)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] byteValue = Encoding.UTF8.GetBytes(value);
            return sha256Hash.ComputeHash(byteValue.Concat(salt));
        }
        static void Main(string[] args)
        {
            
            byte[] salt = SaltGen();
            using (BinaryWriter writer = new BinaryWriter(File.Open("salt-value", FileMode.OpenOrCreate)))
            {
                writer.Write(salt);
            };
            using (BinaryWriter writer = new BinaryWriter(File.Open("salt-password", FileMode.OpenOrCreate)))
            {
                writer.Write(SaltHash("", salt));
            };
        }
    }
}
