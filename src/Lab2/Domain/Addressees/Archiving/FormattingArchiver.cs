using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Archiving;

public class FormattingArchiver : IArchiver
{
    private readonly IMessageFormatter _formatter;

    public FormattingArchiver(IMessageFormatter formatting)
    {
        _formatter = formatting;
    }

    public void Archive(Message message)
    {
        _formatter.WriteTitleMessage(message.Title);
        _formatter.WriteBodyMessage(message.Body);
    }
}