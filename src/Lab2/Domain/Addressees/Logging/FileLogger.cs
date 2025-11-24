using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Logging;

public class FileLogger : ILogger
{
    private readonly string _path;

    public FileLogger(NonEmptyText path)
    {
        _path = path.Value;
    }

    public void Log(string text)
    {
        File.WriteAllText(_path, text);
    }
}