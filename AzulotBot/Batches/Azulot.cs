using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppFramework;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;

namespace AzulotBot.Batches
{
    public class Azulot : ConsoleAppBase
    {
        private DiscordSocketClient _client;
        private readonly IConfiguration _configuration;

        private string Token => _configuration.GetValue<string>("Azulot_Token");

        public Azulot(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Execute()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig{LogLevel = Discord.LogSeverity.Info});
            _client.Log += x =>
            {
                Console.WriteLine($"{x.Message}, {x.Exception}");
                return Task.CompletedTask;
            };
        }
    }
}
