using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class DisconnectParseLink : CommandParseLinkBase
{
    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "disconnect", StringComparison.OrdinalIgnoreCase)) return null;
        if (tokens.MoveNext()) return null;
        return new DisconnectCommand();
    }
}