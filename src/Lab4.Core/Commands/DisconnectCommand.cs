using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class DisconnectCommand : ICommand
{
    public OperationResult Execute(FileSystemContext context)
    {
        if (context.FileSystem is null) return new OperationResult.Failure("File not found");
        context.FileSystem = null;
        context.CurrentPath = "/";

        return new OperationResult.Succes();
    }
}