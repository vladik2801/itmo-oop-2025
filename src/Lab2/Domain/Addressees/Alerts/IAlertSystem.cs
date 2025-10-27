using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public interface IAlertSystem
{
    void Notify(Message message, string reason);
}