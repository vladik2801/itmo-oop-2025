using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class ConnectCommandFactory : ICommandFactory
{
    private readonly IReadOnlyCollection<IConnectionModeStrategy> _strategies;

    public ConnectCommandFactory(IReadOnlyCollection<IConnectionModeStrategy> strategies)
    {
        _strategies = strategies;
    }

    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "connect" && command.SubName is null;
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (command.Arguments.Count < 1) throw new ArgumentException("Invalid command arguments");
        string path = command.Arguments[0];
        string mode = "local";
        if (command.Flags.ContainsKey("m"))
        {
            string? flagKey = command.Flags["m"];
            if (!string.IsNullOrWhiteSpace(flagKey))
            {
                mode = flagKey;
            }
        }

        IConnectionModeStrategy? selectedStrategy = null;
        foreach (IConnectionModeStrategy strategy in _strategies)
        {
            if (strategy.Mode == mode)
            {
                selectedStrategy = strategy;
                break;
            }
        }

        if (selectedStrategy == null) throw new ArgumentException("Invalid connectionn mode");
        IFileSystem fileSystem = selectedStrategy.CreateFileSystem(path);
        return new ConnectCommand(session, fileSystem, path);
    }
}