using Claptrap.Common;

namespace Claptrap.Services.Abstractions;

public interface IConfigService
{
    ClaptrapConfig Config { get; }
}