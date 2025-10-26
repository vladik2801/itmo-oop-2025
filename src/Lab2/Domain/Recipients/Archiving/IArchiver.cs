using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Archiving;

public interface IArchiver
{
    void Archive(Message message);
}