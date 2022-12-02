using Claptrap.Services.Abstractions;
using Claptrap.Services.Commands;
using Jab;
using Serilog;

// ReSharper disable UnusedType.Local

namespace Claptrap.Services;

[ServiceProvider]
[Import<ICommandsProviderModule>]
[Singleton<ILogger>(Instance = nameof(Logger))]
[Singleton<IConfigService, ConfigService>]
[Singleton<IGuildedService, GuildedService>]
public partial class ServiceProvider
{
    public static ServiceProvider Instance { get; private set; } = default!;

    public ILogger Logger => Log.Logger;

    public ServiceProvider()
    {
        Instance = this;
    }
}

[ServiceProviderModule]
[Singleton<IGuildedCommand, RandomCommands>]
file interface ICommandsProviderModule
{
}