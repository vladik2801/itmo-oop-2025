using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting.Archiving;

public class FormattingArchiver : IArchiver
{
    private readonly IMessageFormatter _formatting;

    public FormattingArchiver(IMessageFormatter formatting)
    {
        _formatting = formatting;
    }

    public void Archive(Message message)
    {
        _formatting.Format(message);
    }
}