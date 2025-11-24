using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class FilterAddressees : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly Priority _priority;

    public FilterAddressees(IAddressee addressee, Priority priority)
    {
        _addressee = addressee;
        _priority = priority;
    }

    public void Send(Message message)
    {
        if (message.Priority >= _priority)
        {
            _addressee.Send(message);
        }
    }
}