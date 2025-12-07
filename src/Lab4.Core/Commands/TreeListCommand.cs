using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly Session _session;
    private readonly int _maxDepth;
    private readonly IOutputWriter _outputWriter;

    public TreeListCommand(Session session, int maxDepth,  IOutputWriter outputWriter)
    {
        _session = session;
        _maxDepth = maxDepth;
        _outputWriter = outputWriter;
    }

    public OperationResult Execute()
    {
        if (_session.FileSystem is null) return new OperationResult.Failure("Not connected");
        if (_session.LocalPath is null) return new OperationResult.Failure("Local path not found");
        IFileSystem fileSystem = _session.FileSystem;
        DirectoryEntity? directory = fileSystem.GetDirectoryByPath(_session.LocalPath);
        if (directory is null) return new OperationResult.Failure("Directory not found");
        TreeFormattingVisitor visitor = new(fileSystem, _maxDepth);
        directory.Accept(visitor);
        string tree = visitor.Value;
        _outputWriter.Write(tree);
        return new OperationResult.Succes();
    }
}