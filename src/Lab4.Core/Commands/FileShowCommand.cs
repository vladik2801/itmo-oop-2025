using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Strategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _path;
    private readonly IFileOutputMode _mode;

    public FileShowCommand(string path, IFileOutputMode mode)
    {
        _path = path;
        _mode = mode;
    }

    public OperationResult Execute(FileSystemContext context)
    {
        if (context.FileSystem is null) return new OperationResult.Failure("File not found");
        if (context.CurrentPath is null) return new OperationResult.Failure("Local path not found");
        string absolutePath = context.PathService.Convert(context.CurrentPath, _path);
        string text = context.FileSystem.ReadFile(absolutePath);
        _mode.Show(absolutePath, text);
        return new OperationResult.Succes();
    }
}