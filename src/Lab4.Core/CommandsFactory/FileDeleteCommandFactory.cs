using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class FileDeleteCommandFactory : ICommandFactory
{
    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "file" && command.SubName == "delete";
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (!CanHandle(command)) throw new ArgumentException("Cannot handle command file delete");
        if (command.Arguments.Count < 1) throw new ArgumentException("file delete requires");

        string path = command.Arguments[0];
        return new FileDeleteCommand(session, path);
    }
}