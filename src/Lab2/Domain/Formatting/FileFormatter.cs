using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public sealed class FileFormatter : IMessageFormatter
{
    private readonly string _filePath;

    public FileFormatter(NonEmptyText path)
    {
        _filePath = path.Value;
    }

    public void WriteTitleMessage(string title)
    {
        File.WriteAllText(_filePath, title);
    }

    public void WriteBodyMessage(string body)
    {
        File.WriteAllText(_filePath, body);
    }
}