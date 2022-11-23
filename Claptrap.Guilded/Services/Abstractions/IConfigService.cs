using Claptrap.Config;

namespace Claptrap.Services.Abstractions;

public interface IConfigService
{
    ClaptrapConfig Config { get; }

    T? ReadDataSet<T>(string datasetName);
}