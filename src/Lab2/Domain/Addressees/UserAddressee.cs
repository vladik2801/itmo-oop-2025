using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class UserAddressee : IAddressee
{
    private readonly User _user;

    public UserAddressee(User user)
    {
        _user = user;
    }

    public void Send(Message message)
    {
        _user.Receive(message);
    }
}