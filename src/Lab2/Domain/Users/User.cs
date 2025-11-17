using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;

public sealed class User
{
    private readonly Dictionary<Message, ReadState> _inbox;

    public User(NonEmptyText username)
    {
        UserName = username.Value;
        _inbox = new Dictionary<Message, ReadState>();
    }

    public string UserName { get; }

    public void Receive(Message message)
    {
        _inbox[message] = ReadState.Unread;
    }

    public Result MakeRead(Message message)
    {
        if (!_inbox.ContainsKey(message)) return new Result.NotFound();
        if (_inbox[message] == ReadState.Read) return new Result.AlreadyRead();
        return new Result.Succes();
    }
}