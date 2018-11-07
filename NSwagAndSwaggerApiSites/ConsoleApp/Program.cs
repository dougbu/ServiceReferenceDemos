using System;
using System.Threading.Tasks;
using ClientConsole;

namespace ConsoleApp
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new Client("http://localhost:5000/basePath");
            var data = await client.ApiValuesTooGetAsync();
            Console.WriteLine(data.UserName);
        }
    }
}
