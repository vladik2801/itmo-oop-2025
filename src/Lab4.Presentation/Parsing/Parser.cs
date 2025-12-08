using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class Parser : IParser
{
    private readonly ICommandParseLink _root;

    public Parser(ICommandParseLink root)
    {
        _root = root;
    }

    public ICommand? Parse(string line)
    {
        return _root.Parse(line);
    }
}