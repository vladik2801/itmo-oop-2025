using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class DecoratorTests
{
    [Fact]
    public void BelowThreshold_ShouldNotCallInner()
    {
        var inner = new AddresseeMock { ExceptedCalls = 0 };

        var sut = new FilterAddressees(inner, Priority.High);
        var message = new Message("t", "b", Priority.Medium);
        sut.Send(message);

        inner.Verify();
    }

    [Fact]
    public void MeetThreshold_ShouldCallInnerOnce()
    {
        var inner = new AddresseeMock { ExceptedCalls = 1 };
        var sut = new FilterAddressees(inner, Priority.Medium);

        var message = new Message("t", "b", Priority.Medium);
        sut.Send(message);

        inner.Verify();
    }

    [Fact]
    public void ShouldLogAndThenSend()
    {
        var logger = new LoggerMock { ExpectedCalls = 2, ExpectedSubstring = "Deliver" };
        var inner = new AddresseeMock { ExceptedCalls = 1 };
        var sut = new LoggingAddressees(inner, logger);

        var msg = new Message("t", "b", Priority.High);
        sut.Send(msg);

        logger.Verify();
        inner.Verify();
    }
}