using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class FileMoveParseLink : CommandParseLinkBase
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "file", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "move", StringComparison.OrdinalIgnoreCase)) return null;

        if (!tokens.MoveNext()) return null;
        string source = tokens.Current;

        if (!tokens.MoveNext()) return null;
        string dest = tokens.Current;
        if (tokens.MoveNext()) return null;
        return new FileMoveCommand(source, dest);
    }
}