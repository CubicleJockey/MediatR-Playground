using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MediatRMessages.Api
{
    /// <summary>
    /// The Application Host
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point into the application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
