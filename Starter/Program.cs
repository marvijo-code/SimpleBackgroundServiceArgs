using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleBackgroundService;

namespace SimpleConsoleClient;

internal class Program
{
    public static async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a parameter.");
            return;
        }

        string parameter = args[0];

        var host = CreateHostBuilder(args, parameter).Build();
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args, string parameter) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService(serviceProvider => new MyBackgroundService(parameter));
            });
}
