using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace NETCORE_20
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            // Need to skip validity check fixed in .NET 2.1. See dotnet/corefx#27405
            var certs = store.Certificates.Find(X509FindType.FindBySerialNumber, "39b7f33dec3c8f83", validOnly: false);

            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, 5000);
                    options.Listen(IPAddress.Loopback, 5001, listenOptions => listenOptions.UseHttps(certs[0]));

                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}
