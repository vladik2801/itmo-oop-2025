using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Topics;

public class Topic
{
    private readonly List<IAddressee> _addressees;

    public Topic(IEnumerable<IAddressee> addressees, NonEmptyText name)
    {
        Name = name.Value;
        _addressees = addressees.ToList();
    }

    public string Name { get; }

    public void AddAddressee(IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(addressee, nameof(addressee));
        _addressees.Add(addressee);
    }

    public void RemoveAddressee(IAddressee addressee)
    {
        _addressees.Remove(addressee);
    }

    public void Send(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.Send(message);
        }
    }
}