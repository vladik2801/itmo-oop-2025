using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting.Archiving;
using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients;

public class ArchiverRecipient : IRecipient
{
   private readonly IArchiver _archiver;

   public ArchiverRecipient(IArchiver archiver)
   {
       _archiver = archiver;
   }

   public void Send(Message message)
   {
       _archiver.Archive(message);
   }
}