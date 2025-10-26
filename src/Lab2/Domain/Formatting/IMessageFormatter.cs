using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public interface IMessageFormatter
{
    void Format(Message message);
}