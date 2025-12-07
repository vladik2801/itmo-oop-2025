using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public class DisconnectComandFactory : ICommandFactory
{
    public bool CanHandle(ParsedCommand command)
    {
        return command.Name == "disconnect" && command.SubName is null;
    }

    public ICommand Create(ParsedCommand command, Session session)
    {
        if (!CanHandle(command)) throw new ArgumentException("Cannot handle command");
        return new DisconnectCommand(session);
    }
}