namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Logging;

public sealed class ConsoleLogger : ILogger
{
    public void Log(string text) => Console.WriteLine($"[INFO ] {text}");
}