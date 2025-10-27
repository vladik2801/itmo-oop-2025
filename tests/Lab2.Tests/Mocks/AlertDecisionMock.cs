using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class AlertDecisionMock : IAlertDecision
{
    public bool ShouldAlert { get; set; }

    public string ExpectedReason { get; set; } = "mock";

    public Message? LastMessage { get; private set; }

    public string? GetReason(Message message)
    {
        LastMessage = message;
        return ShouldAlert ? ExpectedReason : null;
    }
}