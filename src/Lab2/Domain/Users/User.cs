using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;

public sealed class User
{
    private readonly List<EntryBox> _inbox = new();

    public User(int userid, string username)
    {
        UserId = userid;
        UserName = username;
    }

    public int UserId { get; }

    public string UserName { get; }

    public IReadOnlyList<EntryBox> Inbox => _inbox;

    public EntryBox Receive(Message message)
    {
        var entryBox = new EntryBox(message, ReadState.Unread);
        _inbox.Add(entryBox);
        return entryBox;
    }

    public void MakeRead(EntryBox entryBox)
    {
        if (entryBox is null) throw new ArgumentNullException(nameof(entryBox), "entryBox cannot be null.");
        if (_inbox.Contains(entryBox)) throw new InvalidOperationException();
        entryBox.MakeRead();
    }
}