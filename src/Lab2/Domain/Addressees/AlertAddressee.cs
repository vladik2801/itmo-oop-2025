using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class AlertAddressee : IAddressee
{
    private readonly IAlertSystem _alertSystem;
    private readonly IAlertDecision _alertDecision;

    public AlertAddressee(IAlertSystem alertSystem, IAlertDecision alertDecision)
    {
        _alertSystem = alertSystem;
        _alertDecision = alertDecision;
    }

    public void Send(Message message)
    {
        string? reason = _alertDecision.GetReason(message);
        if (reason is not null) _alertSystem.Notify(message, reason);
    }
}