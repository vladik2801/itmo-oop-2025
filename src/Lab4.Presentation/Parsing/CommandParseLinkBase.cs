using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public abstract class CommandParseLinkBase : ICommandParseLink
{
    private ICommandParseLink? _next;

    public ICommandParseLink AddNext(ICommandParseLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    public abstract ParsedCommand? Parse(string line);

    protected ParsedCommand? CallNext(string line)
    {
        return _next is not null ? _next.Parse(line) : null;
    }
}