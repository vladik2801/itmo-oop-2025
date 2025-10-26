using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Alerts;

public class SoundAlertSystem : IAlertSystem
{
    public void Notify(Message message, string reason)
    {
        Console.Beep();
    }
}