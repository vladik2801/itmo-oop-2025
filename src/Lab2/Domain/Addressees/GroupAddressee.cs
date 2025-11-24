using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _group;

    public GroupAddressee(IEnumerable<IAddressee> group)
    {
        _group = group.ToList();
    }

    public void Send(Message message)
    {
        foreach (IAddressee recipient in _group)
        {
            recipient.Send(message);
        }
    }
}