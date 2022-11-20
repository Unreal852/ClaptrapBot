using Claptrap.Services.Abstractions;
using Guilded.Commands;

namespace Claptrap.Services.Commands;

public class RandomCommands : CommandModule, IGuildedCommand
{
    private readonly Random _random = new();

    [Command("dice")]
    [Description("Roll a dice")]
    public Task DiceCommand(CommandEvent commandEvent)
    {
        return commandEvent.ReplyAsync($"Dice rolled : {_random.Next(1, 7)}");
    }
    
    [Command("random", Aliases = new[] { "rand", "rdm" })]
    public Task RandomCommand(CommandEvent commandEvent, int min, int max)
    {
        if (min <= 0 || max <= 0)
        {
            return commandEvent.ReplyAsync($"Zero or negative numbers aren't allowed");
        }
        return commandEvent.ReplyAsync($"Random : {_random.Next(Math.Min(min, max), Math.Max(min, max) + 1)}");
    }
}