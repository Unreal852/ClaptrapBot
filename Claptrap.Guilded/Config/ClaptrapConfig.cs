using Tomlet.Attributes;

namespace Claptrap.Config;

public class ClaptrapConfig
{
    [TomlProperty("Auth.Token")]
    public string Token { get; set; } = default!;

    [TomlProperty("Behaviour.Prefix")]
    public string Prefix { get; set; } = default!;
}