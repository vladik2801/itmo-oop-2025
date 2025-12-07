using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShowCommand : ICommand
{
    private readonly Session _session;
    private readonly UnixPathService _pathService = new();
    private readonly string _path;
    private readonly IFileOutputMode _mode;

    public FileShowCommand(Session session, string path, IFileOutputMode mode)
    {
        _path = path;
        _session = session;
        _mode = mode;
    }

    public OperationResult Execute()
    {
        if (_session.FileSystem is null) return new OperationResult.Failure("File not found");
        if (_session.LocalPath is null) return new OperationResult.Failure("Local path not found");
        string absolutePath = _pathService.Convert(_session.LocalPath, _path);
        string text = _session.FileSystem.ReadFile(absolutePath);
        _mode.Show(absolutePath, text);
        return new OperationResult.Succes();
    }
}