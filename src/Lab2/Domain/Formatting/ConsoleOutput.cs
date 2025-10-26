namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public class ConsoleOutput : IOutput
{
    public void Writeln(string message)
    {
        Console.WriteLine(message);
    }
}