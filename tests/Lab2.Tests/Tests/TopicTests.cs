using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Topics;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class TopicTests
{
    [Fact]
    public void Send_ShouldDeliverToAllRecipients()
    {
        // Arrange
        var r1 = new AddresseeMock(1);
        var r2 = new AddresseeMock(1);
        var sut = new Topic(new IAddressee[] { r1, r2 }, new("Security"));

        // Act
        sut.Send(new Message(new("t"), new("b"), Priority.Medium));

        // Assert
        r1.Verify();
        r2.Verify();
    }
}