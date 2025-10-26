using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Archiving;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messages = new();

    public IReadOnlyList<Message> Messages => _messages;

    public void Archive(Message message)
    {
        _messages.Add(message);
    }
}