using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Alerts;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

public class AlertRecipient : IRecipient
{
    private readonly IAlertSystem _alertSystem;
    private readonly IAlertDecision _alertDecision;

    public AlertRecipient(IAlertSystem alertSystem, IAlertDecision alertDecision)
    {
        _alertSystem = alertSystem;
        _alertDecision = alertDecision;
    }

    public void Send(Message message)
    {
        if (_alertDecision.TryGetAlertReason(message, out string reason))
            _alertSystem.Notify(message, reason);
    }
}