namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileCopyCommand : ICommand
{
    private readonly Session _session;
    private readonly UnixPathService _pathService = new();
    private readonly string _path;
    private readonly string _destinationPath;

    public FileCopyCommand(Session session, string path, string destinationPath)
    {
        _session = session;
        _path = path;
        _destinationPath = destinationPath;
    }

    public OperationResult Execute()
    {
        if (_session.FileSystem is null) return new OperationResult.Failure("File not found");
        if (_session.LocalPath is null) return new OperationResult.Failure("Local path not found");

        string absolutePath = _pathService.Convert(_session.LocalPath, _path);
        string destinationPath = _pathService.Convert(_session.LocalPath, _destinationPath);
        return _session.FileSystem.CopyFile(absolutePath, destinationPath);
    }
}