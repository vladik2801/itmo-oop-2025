namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public class MarkdownFormatter : IMessageFormatter
{
    private readonly IMessageFormatter _formatter;

    public MarkdownFormatter(IMessageFormatter formatter)
    {
        _formatter = formatter;
    }

    public void WriteTitleMessage(string title)
    {
        _formatter.WriteTitleMessage($"# {title}");
    }

    public void WriteBodyMessage(string body)
    {
        _formatter.WriteBodyMessage($"## {body}");
    }
}