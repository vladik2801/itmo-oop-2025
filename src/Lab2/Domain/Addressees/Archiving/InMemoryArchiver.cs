using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Archiving;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages = new();

    public void Archive(Message message)
    {
        _messages.Add(message);
    }
}