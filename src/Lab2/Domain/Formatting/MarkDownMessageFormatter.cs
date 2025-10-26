using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public class MarkDownMessageFormatter : IMessageFormatter
{
    private readonly IOutput _output;

    public MarkDownMessageFormatter(IOutput output)
    {
        _output = output;
    }

    public void Format(Message message)
    {
        _output.Writeln("# " + message.Title);
        _output.Writeln(string.Empty);
        _output.Writeln(message.Body);
        _output.Writeln(string.Empty);
        _output.Writeln("> Priority: " + message.Priority);
    }
}