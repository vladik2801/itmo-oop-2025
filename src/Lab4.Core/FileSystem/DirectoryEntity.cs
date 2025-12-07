using Itmo.ObjectOrientedProgramming.Lab4.Core.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class DirectoryEntity : IFileSystemEntity
{
    private readonly List<IFileSystemEntity> _children = new();

    public IReadOnlyCollection<IFileSystemEntity> Children => _children;

    public DirectoryEntity(string path)
    {
        Path = path;
    }

    public string Path { get; set; }

    public void AddChild(IFileSystemEntity child)
    {
        _children.Add(child);
    }

    public void Accept(IFileSystemEntityVisitor visitor)
    {
        visitor.Visit(this);
    }
}