using System.Drawing;
using Claptrap.Services.Abstractions;
using Guilded.Base.Embeds;
using Guilded.Commands;

namespace Claptrap.Services.Commands;

public class RandomCommands : CommandModule, IGuildedCommand
{
    private readonly Random        _random = new();
    private readonly LolChampion[] _lolChampions;

    public RandomCommands(IConfigService configService)
    {
        _lolChampions = configService.ReadDataSet<LolChampion[]>("lol_dataset") ??
                        throw new Exception("Failed to load lol champions");
    }

    [Command("dice")]
    [Description("Roll a dice")]
    public Task DiceCommand(CommandEvent commandEvent)
    {
        var embed = new Embed()
                   .SetTitle("Dice")
                   .SetDescription($"The dice rolled on face **{_random.Next(1, 7)}**")
                   .SetColor(Color.Lime);
        return commandEvent.ReplyAsync(embeds: embed);
    }

    [Command("random", Aliases = new[] { "rand", "rdm" })]
    public Task RandomCommand(CommandEvent commandEvent, [CommandParam] int min, [CommandParam] int max)
    {
        var embed = new Embed().SetTitle("Random");
        if (min <= 0 || max <= 0)
        {
            embed.SetDescription("**Zero or negative numbers aren't allowed**")
                 .SetColor(Color.Red);

            return commandEvent.ReplyAsync(embeds: embed, isPrivate: true);
        }

        embed.SetDescription($"Your random is **{_random.Next(Math.Min(min, max), Math.Max(min, max) + 1)}**")
             .SetColor(Color.Lime);
        return commandEvent.ReplyAsync(embeds: embed);
    }

    [Command("lol")]
    public Task RandomLoLChampionCommand(CommandEvent commandEvent)
    {
        var embed = new Embed().SetTitle("Random League of Legends champion");

        var champion = _lolChampions[_random.Next(0, _lolChampions.Length)];

        embed.SetDescription($"Your random champion is {champion.Name}, good luck !")
             .SetColor(Color.Lime)
             .SetImage($"https://ddragon.leagueoflegends.com/cdn/img/champion/loading/{champion.Id}_0.jpg");

        return commandEvent.ReplyAsync(embeds: embed);
    }
}

public class LolChampion
{
    public string Id   { get; set; } = default!;
    public string Name { get; set; } = default!;
}