namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public sealed class ConsoleFormatter : IMessageFormatter
{
    public void WriteTitleMessage(string title)
    {
        Console.WriteLine(title);
    }

    public void WriteBodyMessage(string body)
    {
        Console.WriteLine(body);
    }
}