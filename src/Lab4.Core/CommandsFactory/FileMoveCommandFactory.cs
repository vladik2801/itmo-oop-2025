using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class FileMoveCommandFactory : ICommandFactory
{
    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "file" && command.SubName == "move";
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (!CanHandle(command)) throw new ArgumentException("Cannot handle command");

        if (command.Arguments.Count < 2) throw new ArgumentException("file move requires sourcepath and destpath");
        string sourcePath = command.Arguments[0];
        string destPath = command.Arguments[1];

        return new FileMoveCommand(session, sourcePath, destPath);
    }
}