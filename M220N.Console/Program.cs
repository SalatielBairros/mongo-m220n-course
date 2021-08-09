using System;
using System.Linq;
using System.Threading.Tasks;
using M220N.Console.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;

namespace M220N.Console
{
    public class Program
    {
        private static MovieService _service;

        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            //var movie = _service.Get(new { title = "The Princess Bride" });
            var movie = _service.Get10thLongestMovie();
            System.Console.WriteLine(movie["title"]);
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostingContext, configuration) =>
               {
                   configuration.Sources.Clear();
                   configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                   var configurationRoot = configuration.Build();
                   var conn = configurationRoot.GetValue<string>("MongoConnection:ConnectionString");
                   _service = new MovieService(new MongoRepository(conn));
               });
    }
}
