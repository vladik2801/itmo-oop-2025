using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting.Archiving;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class ArchiverMock : IArchiver
{
    private int _calls;

    public int ExpectedCalls { get; set; } = 1;

    public Message? ExpectedMessage { get; set; }

    public void Archive(Message message)
    {
        _calls++;
        if (ExpectedMessage is not null && !ReferenceEquals(ExpectedMessage, message))
        {
            throw new Xunit.Sdk.XunitException("Unexpected message");
        }
    }

    public void Verify() => Assert.Equal(ExpectedCalls, _calls);
}