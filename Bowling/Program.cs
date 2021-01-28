using System.Threading.Tasks;
using Bowling.Interfaces;
using Bowling.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bowling
{
    public class Program
    {
        private static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();

            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var service = provider.GetRequiredService<IGame>();
            service.StartGame(@".\Input.csv");

            return host.RunAsync();
        }

        private static IHostBuilder
            CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_,
                        services) =>
                    services

                        //.AddSingleton<IInputReader>(sp
                        //    => new ConsoleInputReader(args[0]))
                        .AddSingleton<IInputService, InputService>()
                        .AddSingleton<IGame, Game>()
                        .AddSingleton<IScoreService, ScoreService>()
                        .AddSingleton<IFrameService, FrameService>()
                        .AddSingleton<ISummaryService, SummaryService>());
        }
    }
}