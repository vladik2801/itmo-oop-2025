namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly Session _session;
    private readonly UnixPathService _pathService = new();
    private readonly string _path;

    public FileDeleteCommand(Session session, string path)
    {
        _session = session;
        _path = path;
    }

    public OperationResult Execute()
    {
        if (_session.FileSystem is null) return new OperationResult.Failure("File not found");
        if (_session.LocalPath is null) return new OperationResult.Failure("Local path not found");

        string absolutePath = _pathService.Convert(_session.LocalPath, _path);
        return _session.FileSystem.DeleteFile(absolutePath);
    }
}