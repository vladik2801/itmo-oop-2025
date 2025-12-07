using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public interface ICommandParseLink
{
    ICommandParseLink AddNext(ICommandParseLink link);

    ParsedCommand? Parse(string line);
}