namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ParsedCommand
{
    public ParsedCommand(
        string name,
        string? subName,
        IReadOnlyList<string> arguments,
        IReadOnlyDictionary<string, string?> flags)
    {
        Name = name;
        SubName = subName;
        Arguments = arguments;
        Flags = flags;
    }

    public string Name { get; }

    public string? SubName { get; }

    public IReadOnlyList<string> Arguments { get; }

    public IReadOnlyDictionary<string, string?> Flags { get; }
}