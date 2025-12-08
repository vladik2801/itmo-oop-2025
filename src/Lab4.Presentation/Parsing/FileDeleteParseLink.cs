using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class FileDeleteParseLink : CommandParseLinkBase
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "file", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "delete", StringComparison.OrdinalIgnoreCase)) return null;

        if (!tokens.MoveNext()) return null;
        string path = tokens.Current;
        if (tokens.MoveNext()) return null;
        return new FileDeleteCommand(path);
    }
}