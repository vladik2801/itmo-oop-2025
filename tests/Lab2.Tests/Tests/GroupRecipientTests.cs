using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;
using Message = Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects.Message;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class GroupRecipientTests
{
    [Fact]
    public void Deliver_ShouldForwardToAllChildren()
    {
        var r1 = new RecipientMock { ExceptedCalls = 1 };
        var r2 = new RecipientMock { ExceptedCalls = 1 };

        var sut = new GroupRecipient(new IRecipient[] { r1, r2 });

        var message = new Message("t", "b", Priority.Medium);
        sut.Send(message);

        r1.Verify();
        r2.Verify();
    }

    [Fact]
    public void Deliver_ShouldWorkWithNestedGroup()
    {
        var leaf = new RecipientMock { ExceptedCalls = 1 };
        var nested = new GroupRecipient(new IRecipient[] { leaf });
        var root = new GroupRecipient(new IRecipient[] { nested });

        root.Send(new Message("t", "b", Priority.High));
        leaf.Verify();
    }
}