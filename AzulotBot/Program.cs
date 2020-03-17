using System;
using System.Threading.Tasks;
using AzulotBot.Batches;
using ConsoleAppFramework;
using Microsoft.Extensions.Hosting;

namespace AzulotBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync<Azulot>(args);
        }
    }
}
