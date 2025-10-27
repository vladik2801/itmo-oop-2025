using Itmo.ObjectOrientedProgramming.Lab2.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public class FileFormatter : IMessageFormatter, IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed;

    public FileFormatter(string path, bool append = true)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Path is required", nameof(path));

        string full = Path.GetFullPath(path);
        string? dir = Path.GetDirectoryName(full);
        if (!string.IsNullOrEmpty(dir))
            Directory.CreateDirectory(dir);
        _writer = new StreamWriter(new FileStream(
            full,
            append ? FileMode.Append : FileMode.Create,
            FileAccess.Write,
            FileShare.Read));
    }

    public void Format(Message message)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        _writer.WriteLine("# " + message.Title);
        _writer.WriteLine(string.Empty);
        _writer.WriteLine(message.Body);
        _writer.WriteLine(string.Empty);
        _writer.WriteLine("> Priority: " + message.Priority);
        _writer.Flush();
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _writer.Dispose();
    }
}