namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRenameCommand : ICommand
{
    private readonly Session _session;
    private readonly UnixPathService _pathService = new();
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(Session session, string path, string newName)
    {
        _session = session;
        _path = path;
        _newName = newName;
    }

    public OperationResult Execute()
    {
        if (_session.FileSystem is null) return new OperationResult.Failure("File not found");
        if (_session.LocalPath is null) return new OperationResult.Failure("Local path not found");

        string absolutePath = _pathService.Convert(_session.LocalPath, _path);
        return _session.FileSystem.RenameFile(absolutePath, _newName);
    }
}