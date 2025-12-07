using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.CommandsFactory;

public interface ICommandFactory
{
    ICommand Create(ParsedCommand command, Session session);

    bool CanHandle(ParsedCommand command);
}