using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;

public sealed class User
{
    private readonly List<InboxItem> _inbox = new();

    public User(int userid, string username)
    {
        UserId = userid;
        UserName = username;
    }

    public int UserId { get; }

    public string UserName { get; }

    public IReadOnlyList<InboxItem> Inbox => _inbox;

    public InboxItem Receive(Message message)
    {
        var entryBox = new InboxItem(message, ReadState.Unread);
        _inbox.Add(entryBox);
        return entryBox;
    }

    public Result MakeRead(InboxItem inboxItem)
    {
        if (_inbox.Contains(inboxItem)) return Result.Fail("Not Found", "Item not found");
        return inboxItem.MakeRead();
    }
}