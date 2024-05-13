namespace SimpleWindowsService;

public class MyBackgroundService : BackgroundService
{
    private readonly string[] _parameters;
    private const string _logPath = @"C:\Logs\MyBackgroundService.log";
    private int _counter;

    public MyBackgroundService(string[] args)
    {
        _parameters = args;
        File.AppendAllText(_logPath, $"{DateTime.Now}: MyBackgroundService has been created...{_parameters?.Count()}");
        File.AppendAllText(_logPath, $"{DateTime.Now}: MyBackgroundService has been created...{_parameters[0]}");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            File.AppendAllText(_logPath, $"{DateTime.Now}: Initial Parameter[0]: {_parameters[0]} Runtime var: #{_counter++}.{Environment.NewLine}");

            await Task.Delay(1000, stoppingToken);
        }
    }
}
