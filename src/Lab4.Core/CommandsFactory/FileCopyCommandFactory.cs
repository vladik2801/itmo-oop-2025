using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class FileCopyCommandFactory : ICommandFactory
{
    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "file" && command.SubName == "copy";
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (!CanHandle(command)) throw new ArgumentException("Cannot handle command");
        if (command.Arguments.Count < 2) throw new ArgumentException("File copy requires 2 arguments");
        string sourcePath = command.Arguments[0];
        string destPath = command.Arguments[1];

        return new FileCopyCommand(session, sourcePath, destPath);
    }
}