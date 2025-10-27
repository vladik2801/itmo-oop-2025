using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Alerts;

public class TextAlertSystem : IAlertSystem
{
    private readonly string _prefix;

    public TextAlertSystem(string prefix = "[Alert System]")
    {
        _prefix = prefix;
    }

    public void Notify(Message message, string reason)
    {
        Console.WriteLine($"{_prefix} {reason} — Message: '{message.Title}'");
    }
}