using Microsoft.Extensions.Hosting;

namespace SimpleBackgroundService;

public class MyBackgroundService : BackgroundService
{
    private readonly string _parameter;

    public MyBackgroundService(string parameter)
    {
        _parameter = parameter;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Received parameter: " + _parameter);

        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Background service is running...");
            await Task.Delay(1000, stoppingToken);
        }
    }
}