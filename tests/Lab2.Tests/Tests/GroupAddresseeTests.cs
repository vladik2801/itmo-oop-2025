using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class GroupAddresseeTests
{
    [Fact]
    public void Deliver_ShouldForwardToAllChildren()
    {
        // Arrange
        var r1 = new AddresseeMock(1);
        var r2 = new AddresseeMock(1);
        var sut = new GroupAddressee(new IAddressee[] { r1, r2 });
        var message = new Message(new("t"), new("b"), Priority.Medium);

        // Act
        sut.Send(message);

        // Assert
        r1.Verify();
        r2.Verify();
    }

    [Fact]
    public void Deliver_ShouldWorkWithNestedGroup()
    {
        // Arrange
        var leaf = new AddresseeMock(1);
        var nested = new GroupAddressee(new IAddressee[] { leaf });
        var root = new GroupAddressee(new IAddressee[] { nested });

        // Act
        root.Send(new Message(new("t"), new("b"), Priority.High));

        // Assert
        leaf.Verify();
    }
}