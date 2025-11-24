using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Archiving;

public class InMemoryArchiver : IArchiver
{
    private readonly List<Message> _messagesArchive = new();

    public void Archive(Message message)
    {
        _messagesArchive.Add(message);
    }
}