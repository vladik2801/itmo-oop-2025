using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class TreeGotoParseLink : CommandParseLinkBase
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "tree", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "goto", StringComparison.OrdinalIgnoreCase)) return null;

        if (!tokens.MoveNext()) return null;
        string path = tokens.Current;
        if (tokens.MoveNext()) return null;
        return new TreeGotoCommand(path);
    }
}