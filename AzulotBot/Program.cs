using System;
using System.Threading.Tasks;
using AzulotBot.Batches;
using ConsoleAppFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AzulotBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("^^");
            await Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();
                services.Configure<MyConfig>(hostContext.Configuration.GetSection("MyConfig"));
            }).RunConsoleAppFrameworkAsync<Azulot>(args);
        }
    }

    public class MyConfig
    {
        public string AzulotToken { get; set; }
    }
}
