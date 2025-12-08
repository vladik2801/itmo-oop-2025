using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _path;
    private readonly string _destinationPath;

    public FileMoveCommand(string path, string destinationPath)
    {
        _path = path;
        _destinationPath = destinationPath;
    }

    public OperationResult Execute(FileSystemContext context)
    {
        if (context.FileSystem is null) return new OperationResult.Failure("File not found");
        if (context.CurrentPath is null) return new OperationResult.Failure("Local path not found");
        string absolutePath = context.PathService.Convert(context.CurrentPath, _path);
        string destinationPath = context.PathService.Convert(context.CurrentPath, _destinationPath);
        return context.FileSystem.MoveFile(absolutePath, destinationPath);
    }
}