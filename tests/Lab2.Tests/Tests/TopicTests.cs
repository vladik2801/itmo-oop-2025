using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Topics;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class TopicTests
{
    [Fact]
    public void Send_ShouldDeliverToAllRecipients()
    {
        var r1 = new RecipientMock { ExceptedCalls = 1 };
        var r2 = new RecipientMock { ExceptedCalls = 1 };

        var sut = new Topic(new IRecipient[] { r1, r2 }, "Security");

        sut.Send(new Message("t", "b", Priority.Medium));

        r1.Verify();
        r2.Verify();
    }
}