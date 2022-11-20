using Claptrap.Services;
using Claptrap.Services.Abstractions;
using Claptrap.Services.Commands;
using Jab;
using Serilog;

// ReSharper disable UnusedType.Local

namespace Claptrap.Guilded.Services;

[ServiceProvider]
[Import(typeof(ICommandsProviderModule))]
[Singleton(typeof(ILogger), Instance = nameof(Logger))]
[Singleton(typeof(IConfigService), typeof(ConfigService))]
[Singleton(typeof(IGuildedService), typeof(GuildedService))]
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
[Singleton(typeof(IGuildedCommand), typeof(RandomCommands))]
file interface ICommandsProviderModule
{
}