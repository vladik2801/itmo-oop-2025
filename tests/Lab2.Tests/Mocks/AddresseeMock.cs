using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Mocks;

public sealed class AddresseeMock : IAddressee
{
    private readonly int _expectedCalls;

    private readonly Message _expectedMessage;

    private Message? _message;

    private int _calls;

    public AddresseeMock(int expectedCalls, Message expectedMessage)
    {
        _expectedCalls = expectedCalls;
        _expectedMessage = expectedMessage;
    }

    public void Send(Message message)
    {
        _calls++;
        _message = message;
    }

    public void Verify()
    {
        Assert.Equal(_expectedCalls, _calls);
        Assert.Equal(_expectedMessage, _message);
    }
}