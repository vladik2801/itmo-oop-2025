using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _maxDepth;
    private readonly IOutputWriter _outputWriter;

    public TreeListCommand(int maxDepth, IOutputWriter outputWriter)
    {
        _maxDepth = maxDepth;
        _outputWriter = outputWriter;
    }

    public OperationResult Execute(FileSystemContext context)
    {
        if (context.FileSystem is null) return new OperationResult.Failure("Not connected");
        if (context.CurrentPath is null) return new OperationResult.Failure("Local path not found");

        try
        {
            string tree = context.FileSystem.ListTree(context.CurrentPath, _maxDepth);
            _outputWriter.Write(tree);
            return new OperationResult.Succes();
        }
        catch (Exception ex)
        {
            return new OperationResult.Failure(ex.Message);
        }
    }
}