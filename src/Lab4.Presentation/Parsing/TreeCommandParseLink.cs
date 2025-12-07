using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsing;

public class TreeCommandParseLink : CommandParseLinkBase
{
    public override ParsedCommand? Parse(string line)
    {
        string[] parts = line.Split(' ');
        if (parts.Length == 0) return null;
        if (parts[0] != "tree") return CallNext(line);
        if (parts.Length < 2) throw new ArgumentException("tree requires subcommand");

        string sub = parts[1];
        List<string> args = new();
        Dictionary<string, string?> flags = new();
        for (int i = 2; i < parts.Length; i++)
        {
            string token = parts[i];
            if (token.StartsWith('-'))
            {
                string key = token.TrimStart('-');
                string? value = null;
                if (i + 1 < parts.Length && !parts[i + 1].StartsWith('-')) value = parts[i + 1];
                flags[key] = value;
            }
            else
            {
                args.Add(token);
            }
        }

        return new ParsedCommand("tree", sub, args, flags);
    }
}