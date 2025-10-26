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

        EntryBox entry = user.Receive(message);

        Assert.Equal(ReadState.Unread, entry.ReadState);
    }

    [Fact]
    public void MarkRead_Twice_ShouldThrow()
    {
        var user = new User(1, "Vlad");
        var message = new Message("t", "b", Priority.Medium);

        EntryBox entry = user.Receive(message);
        entry.MakeRead();

        Assert.Throws<InvalidOperationException>(() => entry.MakeRead());
    }
}