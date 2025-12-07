using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public sealed class ConnectCommandParseLink : CommandParseLinkBase
{
    public override ParsedCommand? Parse(string line)
    {
        string[] parts = line.Split(' ');
        if (parts.Length == 0) return null;
        if (parts[0] != "connect") return CallNext(line);

        if (parts.Length < 2) throw new ArgumentException("Connect requires two arguments");
        string name = "connect";
        string? subName = null;
        string address = parts[1];
        string[] arguments = new[] { address };

        var flags = new Dictionary<string, string?>();
        for (int i = 2; i < parts.Length; i++)
        {
            if (parts[i].StartsWith('-') == false) continue;
            string key = parts[i].TrimStart('-');
            string? value = null;
            if (i + 1 < parts.Length && !parts[i + 1].StartsWith('-'))
            {
                value = parts[i + 1];
            }

            flags[key] = value;
        }

        return new ParsedCommand(name, subName, arguments, flags);
    }
}