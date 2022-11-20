using Claptrap.Common;
using Claptrap.Services.Abstractions;
using Tomlet;

namespace Claptrap.Services;

public sealed class ConfigService : IConfigService
{
    private ClaptrapConfig? _config;

    public ClaptrapConfig Config => _config ??= LoadConfig();

    private static ClaptrapConfig LoadConfig()
    {
        var configDir = Path.Combine(AppContext.BaseDirectory, "Config");
        if (!Directory.Exists(configDir))
            throw new DirectoryNotFoundException(configDir);
        var filePath = Path.Combine(configDir, "config.toml");
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Config file not found", filePath);
        var tomlDoc = TomlParser.ParseFile(filePath);
        var config = TomletMain.To<ClaptrapConfig>(tomlDoc);
        return config;
    }
}