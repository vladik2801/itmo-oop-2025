using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting.Archiving;

public interface IArchiver
{
    void Archive(Message message);
}