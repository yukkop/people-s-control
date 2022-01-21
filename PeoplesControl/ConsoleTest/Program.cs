using Logic;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] salt = Authorization.SaltGen();
            using (BinaryWriter writer = new BinaryWriter(File.Open("salt-value", FileMode.OpenOrCreate)))
            {
                writer.Write(salt);
            };
            using (BinaryWriter writer = new BinaryWriter(File.Open("salt-password", FileMode.OpenOrCreate)))
            {
                writer.Write(Authorization.SaltHash("B2ling54B2ling3rPL292", salt));
            };
        }
    }
}
