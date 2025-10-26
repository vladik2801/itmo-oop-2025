using Itmo.ObjectOrientedProgramming.Lab2.Domain.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

public class UserRecipient : IRecipient
{
    public UserRecipient(User userInp)
    {
        User = userInp;
    }

    public User User { get; }

    public void Send(Message message)
    {
        User.Receive(message);
    }
}