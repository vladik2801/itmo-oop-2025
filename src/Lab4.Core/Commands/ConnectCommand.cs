using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly IFileSystem _fileSystem;

    public ConnectCommand(IFileSystem fileSystem, string path)
    {
        _path = path;
        _fileSystem = fileSystem;
    }

    public OperationResult Execute(FileSystemContext context)
    {
        if (!context.PathService.IsAbsolutePath(_path)) return new OperationResult.Failure("Path not absolute");
        context.FileSystem = _fileSystem;
        context.CurrentPath = _path;
        return new OperationResult.Succes();
    }
}