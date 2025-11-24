namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public interface IMessageFormatter
{
    void WriteTitleMessage(string title);

    void WriteBodyMessage(string body);
}