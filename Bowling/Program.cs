using System;
using System.IO;
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
            ValidateArguments(args);

            using var host = CreateHostBuilder(args).Build();

            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var gameService = provider.GetRequiredService<IGameService>();
            var score = gameService.StartGame();

            Console.WriteLine(score);
        }

        private static IHostBuilder
            CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_,
                        services) =>
                    services
                        .AddSingleton<IInputService>(sp => new ConsoleInputService(args[0]))
                        .AddSingleton<IGameService, GameService>()
                        .AddSingleton<IScoreService, ScoreService>()
                        .AddSingleton<IFrameService, FrameService>()
                        .AddSingleton<IOutputService, OutputService>());
        }

        private static void ValidateArguments(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid input! Please enter single argument representing a valid path to an input file.");
                throw new InvalidDataException("Invalid parameter. Please pass a valid path to the input file");
            }
        }
    }
}