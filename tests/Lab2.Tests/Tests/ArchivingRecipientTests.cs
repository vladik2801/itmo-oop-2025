using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class ArchivingRecipientTests
{
    [Fact]
    public void Deliver_ShouldCallArchiverOnce()
    {
        var archiver = new ArchiverMock { ExpectedCalls = 1 };
        var sut = new ArchiverRecipient(archiver);

        var message = new Message("t", "b", Priority.Low);
        sut.Send(message);

        archiver.Verify();
    }
}