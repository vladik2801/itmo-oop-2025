namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Logging;

public sealed class ConsoleLogger : ILogger
{
    public void Info(string text) => Console.WriteLine($"[INFO ] {text}");

    public void Warn(string text) => Console.WriteLine($"[WARN ] {text}");

    public void ErrorL(string text, Exception? ex)
    {
        Console.WriteLine($"[ERROR ] {text}");
        if (ex is not null) Console.WriteLine(ex.ToString());
    }
}