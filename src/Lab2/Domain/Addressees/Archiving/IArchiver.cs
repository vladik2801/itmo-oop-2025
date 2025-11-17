using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Archiving;

public interface IArchiver
{
    void Archive(Message message);
}