using Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Archiving;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees;

public class ArchiverAddressee : IAddressee
{
    private readonly IArchiver _archiver;

    public ArchiverAddressee(IArchiver archiver)
    {
        _archiver = archiver;
    }

    public void Send(Message message)
    {
        _archiver.Archive(message);
    }
}