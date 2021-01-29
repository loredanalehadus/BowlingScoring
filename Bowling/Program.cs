using System;
using Bowling.Interfaces;
using Bowling.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bowling
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var gameService = provider.GetRequiredService<IGameService>();
            var score = gameService.StartGame(@".\Resources\Input.csv");

            Console.WriteLine(score);
        }

        private static IHostBuilder
            CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_,
                        services) =>
                    services
                        .AddSingleton<IInputService, InputService>()
                        .AddSingleton<IGameService, GameService>()
                        .AddSingleton<IScoreService, ScoreService>()
                        .AddSingleton<IFrameService, FrameService>()
                        .AddSingleton<IOutputService, OutputService>());
        }
    }
}