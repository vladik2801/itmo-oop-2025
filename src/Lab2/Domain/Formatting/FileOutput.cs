namespace Itmo.ObjectOrientedProgramming.Lab2.Domain.Formatting;

public class FileOutput : IOutput, IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed = false;

    public FileOutput(string path)
    {
        _writer = new StreamWriter(path, append: true);
    }

    public void Writeln(string message)
    {
        ObjectDisposedException.ThrowIf(_disposed, nameof(FileOutput));
        _writer.WriteLine(message);
        _writer.Flush();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            _writer.Dispose();
        }
    }
}