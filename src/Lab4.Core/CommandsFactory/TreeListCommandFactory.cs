using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class TreeListCommandFactory : ICommandFactory
{
    private readonly IOutputWriter _outputWriter;

    public TreeListCommandFactory(IOutputWriter outputWriter)
    {
        _outputWriter = outputWriter;
    }

    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "tree" && command.SubName == "list";
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (!CanHandle(command)) throw new ArgumentException("Invalid command");
        if (!command.Flags.ContainsKey("d")) throw new ArgumentException("tree list requires d");

        string? depthString = command.Flags["d"];
        if (string.IsNullOrEmpty(depthString)) throw new ArgumentException("Depth value for -d cannot be empty");
        int depth;
        try
        {
            depth = int.Parse(depthString);
        }
        catch
        {
            throw new ArgumentException("Depth must be integer.");
        }

        return new TreeListCommand(session, depth, _outputWriter);
    }
}