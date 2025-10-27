using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public class SoundAlertSystem : IAlertSystem
{
    public void Notify(Message message, string reason)
    {
        Console.Beep();
    }
}