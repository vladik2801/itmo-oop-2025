using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public OperationResult Execute(FileSystemContext context)
    {
        if (context.FileSystem is null) return new OperationResult.Failure("File not found");
        if (context.CurrentPath is null) return new OperationResult.Failure("Local path not found");

        string absolutePath = context.PathService.Convert(context.CurrentPath, _path);
        return context.FileSystem.DeleteFile(absolutePath);
    }
}