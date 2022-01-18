using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Logic.Auth.SaltHashToString("Max", Encoding.UTF8.GetBytes("N")));
        }
    }
}
