using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Decorators;

public class FilterRecipients : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly Priority _priority;

    public FilterRecipients(IRecipient recipient, Priority priority)
    {
        _recipient = recipient;
        _priority = priority;
    }

    public void Send(Message message)
    {
        if (message.Priority >= _priority)
        {
            _recipient.Send(message);
        }
    }
}