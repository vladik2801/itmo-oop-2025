using Itmo.ObjectOrientedProgramming.Lab2.Domain;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests.Tests;

public sealed class UserInboxTests
{
    [Fact]
    public void Receive_ShouldCreateUnreadEntry()
    {
        var user = new User(1, "Vlad");
        var message = new Message("t", "b", Priority.Medium);

        InboxItem entry = user.Receive(message);

        Assert.Equal(ReadState.Unread, entry.ReadState);
    }

    [Fact]
    public void MarkRead_Twice_ShouldThrow()
    {
        var user = new User(1, "Vlad");

        Result<Message> created = Message.Create("t", "b", Priority.Medium);
        Assert.True(created.IsSuccess);
        Message message = created.Value ?? throw new Xunit.Sdk.XunitException(
            "Message.Create returned success but Value is null");

        InboxItem item = user.Receive(message);

        Result first = item.MakeRead();
        Assert.True(first.IsSuccess);

        Result second = item.MakeRead();
        Assert.False(second.IsSuccess);
        Assert.Equal("Already read", second.Code);
    }
}