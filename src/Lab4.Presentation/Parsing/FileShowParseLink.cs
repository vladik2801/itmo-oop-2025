using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class FileShowParseLink : CommandParseLinkBase
{
    private readonly IReadOnlyCollection<IFileOutputMode> _modes;

    public FileShowParseLink(IReadOnlyCollection<IFileOutputMode> modes)
    {
        _modes = modes;
    }

    protected override ICommand? TryParse(CommandTokenIterator tokens)
    {
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "file", StringComparison.OrdinalIgnoreCase)) return null;
        if (!tokens.MoveNext()) return null;
        if (!string.Equals(tokens.Current, "show", StringComparison.OrdinalIgnoreCase)) return null;

        if (!tokens.MoveNext()) return null;
        string path = tokens.Current;
        string modeName = "console";
        while (tokens.MoveNext())
        {
            if (tokens.Current == "-m")
            {
                if (!tokens.MoveNext()) return null;
                modeName = tokens.Current;
            }
            else
            {
                return null;
            }
        }

        IFileOutputMode? mode = _modes.FirstOrDefault(m =>
            string.Equals(m.Mode, modeName, StringComparison.OrdinalIgnoreCase));
        if (mode == null) return null;
        return new FileShowCommand(path, mode);
    }
}