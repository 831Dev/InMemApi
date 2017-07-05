using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace InMemApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var url = $"http://*:80/"; 
            Console.WriteLine($"Using Url: {url}");

			var config = new ConfigurationBuilder()
				.AddCommandLine(args)
				.Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
		.UseUrls(url);
                .UseStartup<Startup>()
		.Build();
            host.Run();
        }
    }
}
