using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly IFileSystem _fileSystem;
    private readonly Session _session;
    private readonly UnixPathService _pathService = new();

    public ConnectCommand(Session session, IFileSystem fileSystem, string path)
    {
        _path = path;
        _session = session;
        _fileSystem = fileSystem;
    }

    public OperationResult Execute()
    {
        if (!_pathService.IsAbsolutePath(_path)) return new OperationResult.Failure("Path not absolute");
        _session.Connect(_fileSystem);
        return new OperationResult.Succes();
    }
}