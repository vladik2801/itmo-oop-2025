using Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class UserAddressee : IAddressee
{
    public UserAddressee(User user)
    {
        User = user;
    }

    public User User { get; }

    public void Send(Message message)
    {
        User.Receive(message);
    }
}