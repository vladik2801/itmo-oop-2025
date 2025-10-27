namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Addressees.Logging;

public class FileLogger : ILogger, IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed;

    public FileLogger(string path, bool append = true)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Path is required", nameof(path));

        string full = Path.GetFullPath(path);
        string? dir = Path.GetDirectoryName(full);
        if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);

        _writer = new StreamWriter(new FileStream(
            full,
            append ? FileMode.Append : FileMode.Create,
            FileAccess.Write,
            FileShare.Read));
    }

    public void Info(string text)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        _writer.WriteLine($"[INFO ] {DateTime.UtcNow:O} {text}");
        _writer.Flush();
    }

    public void Warn(string text)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        _writer.WriteLine($"[WARN ] {DateTime.UtcNow:O} {text}");
        _writer.Flush();
    }

    public void LogError(string text, Exception? ex = null)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        _writer.WriteLine($"[ERROR] {DateTime.UtcNow:O} {text}");
        if (ex is not null) _writer.WriteLine(ex.ToString());
        _writer.Flush();
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _writer.Dispose();
    }
}