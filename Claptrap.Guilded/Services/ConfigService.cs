using System.Text.Json;
using Claptrap.Config;
using Claptrap.Services.Abstractions;
using Tomlet;

namespace Claptrap.Services;

public sealed class ConfigService : IConfigService
{
    private static readonly string          ConfigDirectory = Path.Combine(AppContext.BaseDirectory, "Config");
    private                 ClaptrapConfig? _config;

    public ClaptrapConfig Config => _config ??= LoadConfig();

    public T? ReadDataSet<T>(string datasetName)
    {
        if (!datasetName.EndsWith("json"))
            datasetName += ".json";
        var filePath = Path.Combine(ConfigDirectory, datasetName);
        if (!File.Exists(filePath))
            return default;
        var fileContent = File.ReadAllText(Path.Combine(ConfigDirectory, datasetName));
        var deserialized = JsonSerializer.Deserialize<T>(fileContent);
        return deserialized;
    }

    private static ClaptrapConfig LoadConfig()
    {
        if (!Directory.Exists(ConfigDirectory))
            throw new DirectoryNotFoundException(ConfigDirectory);
        var filePath = Path.Combine(ConfigDirectory, "config.toml");
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Config file not found", filePath);
        var tomlDoc = TomlParser.ParseFile(filePath);
        var config = TomletMain.To<ClaptrapConfig>(tomlDoc);
        return config;
    }
}