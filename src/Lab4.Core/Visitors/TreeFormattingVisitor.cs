using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

public class TreeFormattingVisitor : IFileSystemEntityVisitor
{
    private readonly StringBuilder _builder = new();

    private readonly IFileSystem _fileSystem;

    private readonly int _maxDepth;

    private int _currentDepth;

    public TreeFormattingVisitor(IFileSystem fileSystem, int maxDepth)
    {
        _maxDepth = maxDepth;
        _fileSystem = fileSystem;
        _currentDepth = 0;
    }

    public string Value => _builder.ToString();

    public void Visit(FileEntity file)
    {
        AppendIndent();
        _builder.AppendLine(file.Path);
    }

    public void Visit(DirectoryEntity directory)
    {
        AppendIndent();
        _builder.AppendLine(directory.Path);
        if (_currentDepth >= _maxDepth) return;
        _currentDepth++;
        foreach (IFileSystemEntity child in _fileSystem.EnumerateChildren(directory))
        {
            child.Accept(this);
        }

        _currentDepth--;
    }

    private void AppendIndent()
    {
        int padding = 2;
        _builder.Append(' ', _currentDepth * padding);
    }
}