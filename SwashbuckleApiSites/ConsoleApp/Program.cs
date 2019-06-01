using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new swashbuckleStringClient(new HttpClient())
            {
                BaseUrl = "http://localhost:5000/basePath",
            };

            // Method returns an ICollection<string>.
            var data = await client.GetAsync();
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
