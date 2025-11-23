using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class DecoratorTests
{
    [Fact]
    public void BelowThreshold_ShouldNotCallInner()
    {
        // Arrange
        var inner = new AddresseeMock(0);
        var sut = new FilterAddressees(inner, Priority.High);
        var message = new Message(new("t"), new("b"), Priority.Medium);

        // Act
        sut.Send(message);

        // Assert
        inner.Verify();
    }

    [Fact]
    public void MeetThreshold_ShouldCallInnerOnce()
    {
        // Arrange
        var inner = new AddresseeMock(1);
        var sut = new FilterAddressees(inner, Priority.Medium);
        var message = new Message(new("t"), new("b"), Priority.Medium);

        // Act
        sut.Send(message);

        // Assert
        inner.Verify();
    }

    [Fact]
    public void Send_ShouldLogTwiceAndCallInnerOnce()
    {
        // Arrange
        var logger = new LoggerMock(1);
        var inner = new AddresseeMock(1);
        var sut = new LoggingAddressees(inner, logger);
        var msg = new Message(new("t"), new("b"), Priority.High);

        // Act
        sut.Send(msg);

        // Assert
        logger.Verify();
        inner.Verify();
    }
}