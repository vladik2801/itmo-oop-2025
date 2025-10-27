using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

public class InboxItem
{
    public InboxItem(Message message, ReadState readState)
    {
        Message = message;
        ReadState = readState;
    }

    public Message Message { get; }

    public ReadState ReadState { get; private set; }

    public Result MakeRead()
    {
        if (ReadState == ReadState.Read) return Result.Fail("Already read");
        ReadState = ReadState.Read;
        return Result.Ok();
    }
}