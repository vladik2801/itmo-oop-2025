using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _group = new();

    public GroupRecipient(IEnumerable<IRecipient> group)
    {
        if (group is not null) _group.AddRange(group);
    }

    public void Add(IRecipient recipient)
    {
        _group.Add(recipient);
    }

    public void Remove(IRecipient recipient)
    {
        _group.Remove(recipient);
    }

    public IReadOnlyCollection<IRecipient> Group => _group;

    public void Send(Message message)
    {
        foreach (IRecipient recipient in _group)
        {
            recipient.Send(message);
        }
    }
}