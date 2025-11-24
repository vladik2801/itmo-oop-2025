namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public class TextAlertSystem : IAlertSystem
{
    private readonly string _prefix;

    public TextAlertSystem(string prefix)
    {
        _prefix = prefix;
    }

    public void Notify()
    {
        Console.WriteLine(_prefix);
    }
}