using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class AlertRecipientTests
{
    [Fact]
    public void WhenPolicySaysAlert_ShouldNotifySystem()
    {
        var system = new AlertSystemMock { ExpectedCalls = 1 };
        var policy = new AlertDecisionMock { Result = true, Reason = "virus" };

        var sut = new AlertRecipient(system, policy);

        sut.Send(new Message("t", "virus found", Priority.High));

        system.Verify();
    }

    [Fact]
    public void WhenPolicySaysNo_ShouldNotNotify()
    {
        var system = new AlertSystemMock { ExpectedCalls = 0 };
        var policy = new AlertDecisionMock { Result = false };

        var sut = new AlertRecipient(system, policy);

        sut.Send(new Message("t", "all good", Priority.Low));

        system.Verify();
    }
}