using System;
using System.Net.Http;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FowlerIsAmazing("http://localhost", new HttpClient());
            Console.WriteLine("Hello World!");
        }
    }
}
