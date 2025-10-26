using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

public class EntryBox
{
    public EntryBox(Message message, ReadState readState)
    {
        Message = message;
        ReadState = readState;
    }

    public Message Message { get; }

    public ReadState ReadState { get; private set; }

    public void MakeRead()
    {
        if (ReadState == ReadState.Read) throw new InvalidOperationException();
        ReadState = ReadState.Read;
    }
}