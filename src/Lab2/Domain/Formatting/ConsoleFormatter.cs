using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public sealed class ConsoleFormatter : IMessageFormatter
{
    public void Format(Message message)
    {
        Console.WriteLine("# " + message.Title);
        Console.WriteLine(string.Empty);
        Console.WriteLine(message.Body);
        Console.WriteLine(string.Empty);
        Console.WriteLine("> Priority: " + message.Priority);
    }
}