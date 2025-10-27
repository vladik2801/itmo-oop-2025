using Itmo.ObjectOrientedProgramming.Lab2.Domain;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class AlertAddresseeTests
{
    [Fact]
    public void WhenPolicySaysAlert_ShouldNotifySystem()
    {
        var system = new AlertSystemMock { ExpectedCalls = 1 };
        var policy = new AlertDecisionMock { ShouldAlert = true, ExpectedReason = "virus" };

        var sut = new AlertAddressee(system, policy);
        Result<Message> created = Message.Create("t", "virus found", Priority.High);
        Assert.True(created.IsSuccess);
        Message msg = created.Value ?? throw new Xunit.Sdk.XunitException("Message.Create returned success but Value is null");
        sut.Send(msg);

        system.Verify();
    }

    [Fact]
    public void WhenPolicySaysNo_ShouldNotNotify()
    {
        var system = new AlertSystemMock { ExpectedCalls = 0 };
        var policy = new AlertDecisionMock { ShouldAlert = false };

        var sut = new AlertAddressee(system, policy);

        sut.Send(new Message("t", "all good", Priority.Low));
        Result<Message> created = Message.Create("t", "all good", Priority.Low);
        Assert.True(created.IsSuccess);
        Message msg = created.Value ?? throw new Xunit.Sdk.XunitException("Message.Create returned success but Value is null");

        sut.Send(msg);

        system.Verify();
    }
}