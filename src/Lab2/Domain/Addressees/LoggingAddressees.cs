using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Logging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

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
        _logger.Info($"Deliver start → {_addressee.GetType().Name}: '{message.Title}' ({message.Priority})");
        try
        {
            _addressee.Send(message);
            _logger.Info($"Deliver success → {_addressee.GetType().Name}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Deliver failed → {_addressee.GetType().Name}", ex);
            throw;
        }
    }
}