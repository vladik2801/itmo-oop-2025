using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class AlertAddressee : IAddressee
{
    private readonly IAlertSystem _alertSystem;
    private readonly ITriggerWordFinder _wordFinder;

    public AlertAddressee(IAlertSystem alertSystem, ITriggerWordFinder alertDecision)
    {
        _alertSystem = alertSystem;
        _wordFinder = alertDecision;
    }

    public void Send(Message message)
    {
        if (_wordFinder.IsTriggerWord(message)) _alertSystem.Notify();
    }
}