using System;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FowlerIsAmazing("http://localhost");
            Console.WriteLine("Hello World!");
        }
    }
}
