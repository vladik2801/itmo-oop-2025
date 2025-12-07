using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class TreeeGotoCommandFactory : ICommandFactory
{
    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "tree" && command.SubName == "goto";
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (!CanHandle(command)) throw new ArgumentException("Cannot handle command");
        if (command.Arguments.Count < 1) throw new ArgumentException("tree goto requires [Path] argument");
        string path = command.Arguments[0];

        return new TreeGotoCommand(session, path);
    }
}