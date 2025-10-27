using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly List<IAddressee> _group = new();

    public GroupAddressee(IEnumerable<IAddressee> group)
    {
        if (group is not null) _group.AddRange(group);
    }

    public void Add(IAddressee addressee)
    {
        _group.Add(addressee);
    }

    public void Send(Message message)
    {
        foreach (IAddressee recipient in _group)
        {
            recipient.Send(message);
        }
    }
}