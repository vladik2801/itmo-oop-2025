using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Alerts;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class AlertDecisionMock : IAlertDecision
{
    public bool Result { get; set; }

    public string Reason { get; set; } = "mock";

    public bool TryGetAlertReason(Message message, out string reason)
    {
        reason = Reason;
        return Result;
    }
}