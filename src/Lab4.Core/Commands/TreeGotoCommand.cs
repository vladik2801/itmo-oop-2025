using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(string path)
    {
        _path = path;
    }

    public OperationResult Execute(FileSystemContext context)
    {
        if (context.FileSystem is null) return new OperationResult.Failure("File not found");
        if (context.CurrentPath is null) return new OperationResult.Failure("Local path not found");
        string newLocalPath = context.PathService.Convert(context.CurrentPath, _path);
        context.CurrentPath = newLocalPath;
        return new OperationResult.Succes();
    }
}