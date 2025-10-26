using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Logging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Decorators;

public class LoggingRecipients : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public LoggingRecipients(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void Send(Message message)
    {
        _logger.Info($"Deliver start → {_recipient.GetType().Name}: '{message.Title}' ({message.Priority})");
        try
        {
            _recipient.Send(message);
            _logger.Info($"Deliver success → {_recipient.GetType().Name}");
        }
        catch (Exception ex)
        {
            _logger.ErrorL($"Deliver failed → {_recipient.GetType().Name}", ex);
            throw;
        }
    }
}