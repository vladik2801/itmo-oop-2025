using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public OperationResult Execute(FileSystemContext context)
    {
        if (context.FileSystem is null) return new OperationResult.Failure("File not found");
        if (context.CurrentPath is null) return new OperationResult.Failure("Local path not found");

        string absolutePath = context.PathService.Convert(context.CurrentPath, _path);
        return context.FileSystem.RenameFile(absolutePath, _newName);
    }
}