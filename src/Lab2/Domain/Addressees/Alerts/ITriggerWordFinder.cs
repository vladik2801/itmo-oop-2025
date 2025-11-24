using Itmo.ObjectOrientedProgramming.Lab2.Domain.Messaging;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public interface ITriggerWordFinder
{
    bool IsTriggerWord(Message message);
}