using Itmo.ObjectOrientedProgramming.Lab4.Core;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class TreeListParserLink : CommandParseLinkBase
{
    private readonly IOutputWriter _writer;

    public TreeListParserLink(IOutputWriter writer)
    {
        _writer = writer;
    }

    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "tree", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "list", StringComparison.OrdinalIgnoreCase)) return null;

        int depth = 1;
        while (tokens.MoveNext())
        {
            if (tokens.Current == "-d")
            {
                if (!tokens.MoveNext()) return null;
                try
                {
                    depth = int.Parse(tokens.Current);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        return new TreeListCommand(depth, _writer);
    }
}