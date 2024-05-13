using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleWindowsService;

var builder = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "SimpleWindowsService";
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.Configure<HostOptions>(options =>
        {
            options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
        });

        var configuration = hostContext.Configuration;
        var parameter = configuration.GetValue<string>("Parameter");
        services.AddHostedService(serviceProvider => new MyBackgroundService(new[] { parameter }));
    });

var host = builder.Build();
host.Run();