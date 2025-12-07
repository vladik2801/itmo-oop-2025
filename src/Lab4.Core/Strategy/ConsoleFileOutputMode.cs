namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

public class ConsoleFileOutputMode : IFileOutputMode
{
    private readonly IOutputWriter _writer;

    public ConsoleFileOutputMode(IOutputWriter writer)
    {
        _writer = writer;
    }

    public string Mode => "console";

    public void Show(string filePath, string context)
    {
        _writer.Write(context);
    }
}