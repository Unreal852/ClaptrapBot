namespace Claptrap.Services.Abstractions;

public interface IGuildedService
{
    Task ConnectAsync();
    Task DisconnectAsync();
}