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

    public ICommand? Parse(string line)
    {
        using var tokens = new CommandTokenIterator(line);
        ICommand? result = TryParse(tokens);
        if (result is null) return result;
        return _next?.Parse(line);
    }

    protected abstract ICommand? TryParse(CommandTokenIterator tokens);
}