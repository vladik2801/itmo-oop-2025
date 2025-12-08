using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public sealed class ConnectCommandParseLink : CommandParseLinkBase
{
    private readonly IReadOnlyCollection<IConnectionModeStrategy> _strategies;

    public ConnectCommandParseLink(IReadOnlyCollection<IConnectionModeStrategy> strategies)
    {
        _strategies = strategies;
    }

    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "connect", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        string path = tokens.Current;
        string mode = "local";
        while (tokens.MoveNext())
        {
            if (tokens.Current == "m")
            {
                if (!tokens.MoveNext()) return null;
                mode = tokens.Current;
            }
            else
            {
                return null;
            }
        }

        IConnectionModeStrategy? strategy = null;
        foreach (IConnectionModeStrategy strat in _strategies)
        {
            if (strat.Mode == mode)
            {
                strategy = strat;
                break;
            }
        }

        if (strategy is null) return null;
        IFileSystem fileSystem = strategy.CreateFileSystem(path);
        return new ConnectCommand(fileSystem, path);
    }
}