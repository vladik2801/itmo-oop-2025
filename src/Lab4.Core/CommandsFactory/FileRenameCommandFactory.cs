using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class FileRenameCommandFactory : ICommandFactory
{
    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "file" && command.SubName == "rename";
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (!CanHandle(command)) throw new ArgumentException("Cannot handle command file name");
        if (command.Arguments.Count < 2) throw new ArgumentException("Invalid number of arguments");
        string path = command.Arguments[0];
        string newName = command.Arguments[1];

        return new FileRenameCommand(session, path, newName);
    }
}