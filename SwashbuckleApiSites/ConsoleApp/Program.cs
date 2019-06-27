using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new SwashbuckleStringTemplate21("http://localhost:5000/basePath", new HttpClient());

            // Method returns an ICollection<string>.
            var data = await client.ApiValuesGetAsync();
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
