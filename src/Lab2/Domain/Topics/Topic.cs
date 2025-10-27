using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Topics;

public class Topic
{
    private readonly List<IAddressee> _recipients = new();

    public Topic(IEnumerable<IAddressee> recipients, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Topic name is required.", nameof(name));
        Name = name;
        foreach (IAddressee recipient in recipients)
        {
            AddRecipient(recipient);
        }
    }

    public IReadOnlyCollection<IAddressee> Recipients => _recipients;

    public string Name { get; }

    public void AddRecipient(IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(addressee, nameof(addressee));
        _recipients.Add(addressee);
    }

    public void RemoveRecipient(IAddressee addressee)
    {
        _recipients.Remove(addressee);
    }

    public void Send(Message message)
    {
        foreach (IAddressee recipient in _recipients)
        {
            recipient.Send(message);
        }
    }
}