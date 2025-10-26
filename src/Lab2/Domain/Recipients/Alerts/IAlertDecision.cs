using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Alerts;

public interface IAlertDecision
{
    bool TryGetAlertReason(Message message, out string reason);
}