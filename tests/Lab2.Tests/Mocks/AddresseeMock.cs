using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class AddresseeMock : IAddressee
{
    private int _calls;

    public int ExceptedCalls { get; set; } = 1;

    public Message? ExceptedMessage { get; set; }

    public void Send(Message message)
    {
        _calls++;
        if (ExceptedMessage is not null && !ReferenceEquals(ExceptedMessage, message))
        {
            throw new Xunit.Sdk.XunitException("Unexcepted message was not received");
        }
    }

    public void Verify() => Assert.Equal(ExceptedCalls, _calls);
}