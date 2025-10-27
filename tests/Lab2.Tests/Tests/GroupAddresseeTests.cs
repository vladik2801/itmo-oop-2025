using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;
using Message = Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects.Message;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class GroupAddresseeTests
{
    [Fact]
    public void Deliver_ShouldForwardToAllChildren()
    {
        var r1 = new AddresseeMock { ExceptedCalls = 1 };
        var r2 = new AddresseeMock { ExceptedCalls = 1 };

        var sut = new GroupAddressee(new IAddressee[] { r1, r2 });

        var message = new Message("t", "b", Priority.Medium);
        sut.Send(message);

        r1.Verify();
        r2.Verify();
    }

    [Fact]
    public void Deliver_ShouldWorkWithNestedGroup()
    {
        var leaf = new AddresseeMock { ExceptedCalls = 1 };
        var nested = new GroupAddressee(new IAddressee[] { leaf });
        var root = new GroupAddressee(new IAddressee[] { nested });

        root.Send(new Message("t", "b", Priority.High));
        leaf.Verify();
    }
}