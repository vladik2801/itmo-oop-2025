using Itmo.ObjectOrientedProgramming.Lab4.Core;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class ConsoleOutputWriter : IOutputWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}