using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class Parser : IParser
{
    private readonly ConnectCommandParseLink _first;

    public Parser()
    {
        ConnectCommandParseLink connect = new();
        TreeCommandParseLink tree = new();
        FileCommandParseLink file = new();
        connect.AddNext(tree).AddNext(file);
        _first = connect;
    }

    public ParsedCommand? Parse(string? line)
    {
        if (string.IsNullOrWhiteSpace(line)) return null;
        return _first.Parse(line);
    }
}