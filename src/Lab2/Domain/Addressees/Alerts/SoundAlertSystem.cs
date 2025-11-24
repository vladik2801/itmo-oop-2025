namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public class SoundAlertSystem : IAlertSystem
{
    public void Notify()
    {
        Console.Beep();
    }
}