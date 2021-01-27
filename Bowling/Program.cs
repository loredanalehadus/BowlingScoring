using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bowling
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var input = File.ReadAllText(@".\Input.csv");
            var rolls = input.Split(',').Select(int.Parse);


        }

        //static Task Main(string[] args)
        //{
        //    using IHost host = CreateHostBuilder(args).Build();

        //    ConfigureServices(host.Services, "Scope 1");

        //    return host.RunAsync();
        //}

        //static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args);

        //static void ConfigureServices(IServiceProvider services, string scope)
        //{
        //    using IServiceScope serviceScope = services.CreateScope();
        //    IServiceProvider provider = serviceScope.ServiceProvider;

        //    OperationLogger logger = provider.GetRequiredService<OperationLogger>();
        //    logger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

        //    Console.WriteLine("...");

        //    logger = provider.GetRequiredService<OperationLogger>();
        //    logger.LogOperations($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

        //    Console.WriteLine();
        //}
    }
}
