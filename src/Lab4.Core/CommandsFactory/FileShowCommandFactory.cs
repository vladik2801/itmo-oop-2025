using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class FileShowCommandFactory : ICommandFactory
{
    private readonly IReadOnlyCollection<IFileOutputMode> _strategies;

    public FileShowCommandFactory(IReadOnlyCollection<IFileOutputMode> strategies)
    {
        _strategies = strategies;
    }

    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "file" && command.SubName == "show";
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (command.Arguments.Count < 1) throw new ArgumentException("Invalid command arguments");
        string path = command.Arguments[0];
        string mode = "console";
        if (command.Flags.ContainsKey("m"))
        {
            string? flagKey = command.Flags["m"];
            if (!string.IsNullOrWhiteSpace(flagKey))
            {
                mode = flagKey;
            }
        }

        IFileOutputMode? selectedStrategy = null;
        foreach (IFileOutputMode strategy in _strategies)
        {
            if (strategy.Mode == mode)
            {
                selectedStrategy = strategy;
                break;
            }
        }

        if (selectedStrategy == null) throw new ArgumentException("Unsupported output mode");

        return new FileShowCommand(session, path, selectedStrategy);
    }
}