using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Logging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class LoggingAddressees : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public LoggingAddressees(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void Send(Message message)
    {
        _logger.Log(message.Title);
        _addressee.Send(message);
    }
}