using Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Topics;

public class Topic
{
    private readonly List<IRecipient> _recipients = new();

    public Topic(IEnumerable<IRecipient> recipients, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Topic name is required.", nameof(name));
        Name = name;
        foreach (IRecipient recipient in recipients)
        {
            AddRecipient(recipient);
        }
    }

    public IReadOnlyCollection<IRecipient> Recipients => _recipients;

    public string Name { get; }

    public void AddRecipient(IRecipient recipient)
    {
        ArgumentNullException.ThrowIfNull(recipient, nameof(recipient));
        _recipients.Add(recipient);
    }

    public void RemoveRecipient(IRecipient recipient)
    {
        _recipients.Remove(recipient);
    }

    public void Send(Message message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.Send(message);
        }
    }
}