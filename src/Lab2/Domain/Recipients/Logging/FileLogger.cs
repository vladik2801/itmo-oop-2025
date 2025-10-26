using Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Recipients.Logging;

public class FileLogger : ILogger, IDisposable
{
    private readonly FileOutput _output;

    public FileLogger(string path)
    {
        _output = new FileOutput(path);
    }

    public void Info(string text) => _output.Writeln($"[INFO ] {DateTime.UtcNow:O} {text}");

    public void Warn(string text) => _output.Writeln($"[WARN] {DateTime.UtcNow:O} {text}");

    public void ErrorL(string text, Exception? ex = null)
    {
        _output.Writeln($"[ERROR] {DateTime.UtcNow:O} {text}");
        if (ex is not null) _output.Writeln(ex.ToString());
    }

    public void Dispose() => _output.Dispose();
}