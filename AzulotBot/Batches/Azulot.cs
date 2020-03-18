using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppFramework;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AzulotBot.Batches
{
    public class Azulot : ConsoleAppBase
    {
        private DiscordSocketClient _client;
        private CommandService _command;
        private readonly IOptions<MyConfig> _configuration;

        public Azulot(IOptions<MyConfig> configuration)
        {
            Console.WriteLine(configuration is null);
            _configuration = configuration;
        }

        public async Task Execute()
        {
            Console.WriteLine("^^");
            _command = new CommandService();
            _client = new DiscordSocketClient(new DiscordSocketConfig{LogLevel = Discord.LogSeverity.Info});
            Console.WriteLine($"Token is {_configuration.Value.AzulotToken}");
            _client.Log += x =>
            {
                Console.WriteLine($"{x.Message}, {x.Exception}");
                return Task.CompletedTask;
            };

            _client.MessageReceived += ReceiveCommand;

            Console.CancelKeyPress += async (a, b) =>
            {
                await _client.StopAsync();
                Environment.Exit(0);
            };
            
            Console.WriteLine("Module");
            await _command.AddModulesAsync(Assembly.GetEntryAssembly(), null);
            Console.WriteLine("Login");
            await _client.LoginAsync(TokenType.Bot, _configuration.Value.AzulotToken);
            Console.WriteLine("Start");
            await _client.StartAsync(); 

            await Task.Delay(-1);
        }

        private async Task ReceiveCommand(SocketMessage message)
        {
            if(!(message is SocketUserMessage msg) || msg.Author.IsBot) return;

            var argPos = 0;
            if (!(msg.HasCharPrefix('!', ref argPos)) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos)) return;
            var context = new CommandContext(_client, msg);

            var result = await _command.ExecuteAsync(
                context,
                argPos,
                null);
        }
    }
}
