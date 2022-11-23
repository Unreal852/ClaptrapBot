using Claptrap.Services;
using Claptrap.Services.Abstractions;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Claptrap;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        ConfigureLogger();
        ConfigureServices();

        var guilded = ServiceProvider.Instance.GetService<IGuildedService>();

        await guilded.ConnectAsync();

        while (Console.ReadLine() != "exit")
        {
        }

        await guilded.DisconnectAsync();
    }

    private static void ConfigureLogger()
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console(theme: AnsiConsoleTheme.Code).CreateLogger();
    }

    private static void ConfigureServices()
    {
        _ = new ServiceProvider();
    }
}